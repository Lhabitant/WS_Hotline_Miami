using Pathfinding;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemiAIState : MonoBehaviour
{
    private AIPath AIScript;
    private AIDestinationSetter aIDestinationSetter;
    public GameObject player;
    private float timer;
    public float timeDuration = 2.0f;
    [SerializeField]
    GameObject deathParticle;

    private bool haveCollidedFlag = false;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        AIScript = GetComponent<AIPath>();
        aIDestinationSetter = GetComponent<AIDestinationSetter>();
        AIScript.enabled = false;

    }

    private void FixedUpdate()
    {
        /*
         * Obliger de passer par un FixedUpdate pour éviter d'instensier deux objets à la mort
         * Par exemple le drop d'arme
         */
        DeathImpact();
    }

    private void DeathImpact()
    {
        if (haveCollidedFlag)
        {
            //Soundsystem
            audioManager.Instance.MakeHurtSound();
            //Event system
            EventManager.TriggerEvent("KillEnnemi", 1);
            EventManager.TriggerEvent("AddScorePoint", 100);
            //Destroy self
            Destroy(this.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        AimPlayer();
    }

    private void AimPlayer()
    {
        //Debug.Log(timer);
        RaycastHit2D hit = Physics2D.Raycast(transform.position + transform.up.normalized, transform.up.normalized);
        if (hit.collider != null)
        {
            
            if (hit.collider.tag == "Player" || timer > 0)
            {
                AIScript.enabled = true;
                timer = timeDuration;
                aIDestinationSetter.target = player.transform;
            }
            else
            {
                AIScript.enabled = false;
            }
        }
        timer -= Time.deltaTime;
        if(timer < 0)
        {
            transform.up = player.transform.position - transform.position;
        }
       
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag  == "bullet" || collision.tag == "punch")
        {
            if (collision.tag == "bullet" || collision.tag == "punch")
            {
                //Get direction of hit bullet
                if (collision.tag == "bullet")
                {
                    Vector3 bulletD = collision.gameObject.GetComponent<BulletScript>().normalizeDirection;
                    //Particle System
                    GetComponent<ParticleSystemManager>().InstantiateDeathParticle(bulletD);
                }
            }
            haveCollidedFlag = true;
            //Debug.Log("IAM DEAD NOT BIG SURPRISE");
            
        }
    }

}
