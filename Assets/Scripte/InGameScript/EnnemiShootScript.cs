﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemiShootScript : MonoBehaviour
{
    [Header("Prefab necessary")]
    [SerializeField]
    GameObject player;
    [SerializeField]
    GameObject bullet;


    [Header("Parameter")]
    public bool canShot = true;
    RaycastHit2D raycast;
    private float timer;
    [SerializeField]
    float coolDown = 1;
    
    
    

    [Header("Weapon Information")]
    public WeaponType myWeaponType;
    public BulletType myBulletType;
    public int ammo;
    public int maxAmmo;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        //raycast = Physics2D.Raycast(transform.position, player.transform.position, Mathf.Infinity);
        RaycastHit2D hit = Physics2D.Raycast(transform.position + transform.up.normalized, transform.up.normalized);
        if (canShot)
        {
            if (hit.collider != null)
            {
                //Debug.Log(hit.collider.name);
                if (hit.collider.tag == "Player" && timer <= 0)
                {
                    audioManager.Instance.MakeShotSound();
                    GameObject bulletObject = Instantiate(bullet, transform.position + transform.up.normalized, transform.rotation);
                    //bulletObject.GetComponent<BulletScript>().isEnnemiBullet = true ;
                    timer = coolDown;
                }
            }
        }
            timer -= Time.deltaTime;
            //Debug.Log(this.name);
            transform.up = player.transform.position - transform.position;
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "bullet" || collision.tag == "punch")
        {
            //We put data in a prefab
            WeaponDropAtDeath test = GetComponent<WeaponDropAtDeath>();
            test.SetDataInWeapon();
            //Get direction of hit bullet
            Vector3 bulletD = collision.gameObject.GetComponent<BulletScript>().normalizeDirection;            

            //Event System
            EventManager.TriggerEvent("KillEnnemi", 1);
            EventManager.TriggerEvent("AddScorePoint", 100);
            //Particle System
            GetComponent<ParticleSystemManager>().InstantiateDeathParticle(bulletD);
            //Sound System
            audioManager.Instance.MakeHurtSound();
            //Destroy self
            Destroy(gameObject);
            Destroy(collision);

        }
    }
}
