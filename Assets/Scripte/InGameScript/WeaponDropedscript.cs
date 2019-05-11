using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class WeaponDropedscript : MonoBehaviour
{
    
    public bool isMoving;
    private Vector3 normalizeDirection;
    private Rigidbody2D body;

    [Header("Get Owner Settings")]
    public GameObject owner;
    public BulletType myBulletType;
    public WeaponType myWeaponType;
    public int ammoInside;
    public int maxAmmo;

    [Header("Speed stuff")]
    public float speed = 10f;
    public float slowerSpeed = 80f;
    public float sloWallSpeed = 3;
    public float whenStopMoving = 300f;

    void Awake()
    {
        
    }
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        Vector3 worldPos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10f));
        normalizeDirection = Vector3.Normalize(worldPos - transform.position);
        normalizeDirection = new Vector3(normalizeDirection.x, normalizeDirection.y, 0f);
        //Debug.Log("Normalize direction " + normalizeDirection);
    }

    // Update is called once per frame
    void Update()
    {
        Moving();
    }

    private void Moving()
    {
        body.velocity = normalizeDirection * speed * Time.deltaTime;
        //Debug.Log(body.velocity);
        if(speed >= whenStopMoving)
        {
            speed -= slowerSpeed;
            isMoving = true;
        }
        else if(speed <= whenStopMoving)
        {
            speed = 0;
            isMoving = false;
            GetComponent<Collider2D>().isTrigger = true ;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        normalizeDirection = Vector2.Reflect(normalizeDirection, collision.contacts[0].normal);
        if(collision.gameObject.GetComponent<Rigidbody2D>() != null)
        {
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(-normalizeDirection * speed * Time.deltaTime);
            
        }
        speed = speed / sloWallSpeed;
    }
}
