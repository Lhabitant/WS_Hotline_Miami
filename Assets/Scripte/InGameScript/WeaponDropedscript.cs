using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class WeaponDropedscript : MonoBehaviour
{
    public BulletType myBulletType;
    public bool isMoving;
    public float speed = 10f;
    public float slowerSpeed = 0.1f;
    private Vector3 normalizeDirection;
    private Rigidbody2D body;

    [Header("Get Owner Settings")]
    public GameObject owner;
    private BulletManager bulletManager;
    public int ammoInside;
    public int maxAmmo;

    void Awake()
    {
        
    }
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        if (owner.tag == "player")
        {
            bulletManager = owner.GetComponent<BulletManager>();
            myBulletType = bulletManager.bulletType;
            ammoInside = bulletManager.ammo;
            maxAmmo = bulletManager.maxAmmo;
        }
        Vector3 worldPos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10f));
        normalizeDirection = Vector3.Normalize(worldPos - transform.position);
        normalizeDirection = new Vector3(normalizeDirection.x, normalizeDirection.y, 0f);
        Debug.Log("Normalize direction " + normalizeDirection);
    }

    // Update is called once per frame
    void Update()
    {
        Moving();
    }

    private void Moving()
    {
        body.velocity = normalizeDirection * speed * Time.deltaTime;
        Debug.Log(body.velocity);
        if(speed > 0)
        {
            //speed -= slowerSpeed;
            isMoving = true;
        }
        else if(speed <= 0)
        {
            isMoving = false;
        }
    }
}
