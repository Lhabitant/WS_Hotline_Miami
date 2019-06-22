using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour {

    private BulletManager bulletManager;
    [HideInInspector]
    public Vector3 normalizeDirection;
    [SerializeField]
    float speed = 50;
    [SerializeField]
    float timeLeft = 10f;

    public float minValue = -2;

    public float maxValue = 2;

    [SerializeField]
    GameObject player;
    public GameObject visor;
    [SerializeField]
    GameObject spawnParticle;
    [SerializeField]
    GameObject hitParticle;
    public GameObject camera;

    public BulletType myBulletType = BulletType.Normal;
    public int bouncingNumber = 2;
    private int bouncing = 0; 
    public bool isEnnemiBullet = false;
    Rigidbody2D body;
    Vector3 NormalVecteur = new Vector3(0, 0, 0);
    private BoxCollider2D boxcollider;

    // Use this for initialization
    void Start()
    {
        boxcollider = GetComponent<BoxCollider2D>();
        Instantiate(spawnParticle, transform.position, transform.rotation);
        body = GetComponent<Rigidbody2D>();
        camera = GameObject.Find("Main Camera");
        player = GameObject.Find("Player");
        myBulletType = player.GetComponent<BulletManager>().bulletType;
        GetComponent<Renderer>().material.SetColor("_EmissionColor",player.GetComponent<BulletManager>().bulletColor);
        GetDirection();

    }
    private void GetDirection()
    {
        if (isEnnemiBullet)
        {
            normalizeDirection = (player.transform.position - transform.position).normalized;
            //Debug.Log(player.transform.position);
        }

        else
        {
            GetComponent<Renderer>().material.color = player.GetComponent<BulletManager>().bulletColor;


            Vector3 worldPos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10f));
            Vector3 randomPos = new Vector3(UnityEngine.Random.Range(minValue, maxValue), UnityEngine.Random.Range(minValue, maxValue), 0f);

            normalizeDirection = Vector3.Normalize(worldPos - transform.position + randomPos);
            //Multiply the normal vector to 10 to set it at 1;
            //normalizeDirection = -(camera.GetComponent<CameraControll>().positionWithoutCursor - transform.position + randomPos).normalized * 10;
        }

        normalizeDirection = new Vector3(normalizeDirection.x, normalizeDirection.y, 0f);
        //Debug.Log(normalizeDirection);
    }

    void Update()
    {
        Destroy(gameObject, 5);
        BulletReaction();
    }

    private void BulletReaction()
    {
        switch (myBulletType)
        {
            case BulletType.Normal:
                {
                    break;
                }
            case BulletType.Rebondissante:
                {
                    if (bouncing > bouncingNumber)
                    {
                        Destroy(gameObject);
                    }
                    break;
                }
            case BulletType.Explosion:
                {

                    break;
                }
        }
        body.velocity = normalizeDirection * speed * Time.deltaTime;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        //ParticleEmitter(other);
        if (other.gameObject.tag != "bullet")
        {
            bouncing++;
        }

        if (other.collider.gameObject.tag == "ennemi" && isEnnemiBullet == false)
        {
            if(myBulletType == BulletType.Explosion)
            {
                boxcollider.size = new Vector2(20, 20);
            }
            Destroy(gameObject);
        }
        else if (other.collider.gameObject.tag == "Player" && isEnnemiBullet == true)
        {
            //Destroy(other.collider.gameObject);
            EventManager.TriggerEvent("KillPlayer",0);
        }
        else if (other.collider.gameObject.tag == "ammocontainer")
        {
        }
        else if (other.collider.gameObject.tag != "bullet")
        {
            switch (myBulletType)
            {
                case BulletType.Normal:
                    {
                        Instantiate(hitParticle, transform.position, transform.rotation);
                        Destroy(gameObject);
                        break;
                    }
                case BulletType.Rebondissante:
                    {
                        normalizeDirection = Vector2.Reflect(normalizeDirection, other.contacts[0].normal);
                        break;
                    }
                case BulletType.Explosion:
                    {
                        //Debug.Log("PIG");
                        boxcollider.size = new Vector2(20,20);
                        Instantiate(hitParticle, transform.position, transform.rotation);
                        Destroy(gameObject);
                        break;
                    }
            }
        }
        else if(other.collider.gameObject.tag == "bullet")
        { }
    }

    private void ParticleEmitter(Collision2D other)
    {
       /* ParticlePhysicsExtensions.GetCollisionEvents(particleLauncher, other, collisionEvents);

        for (int i = 0; i < collisionEvents.Count; i++)
        {
            splatDecalPool.ParticleHit(collisionEvents[i], particleColorGradient);
            EmitAtLocation(collisionEvents[i]);
        }*/
    }
}
