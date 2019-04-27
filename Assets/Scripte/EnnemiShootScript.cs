﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemiShootScript : MonoBehaviour
{
    [SerializeField]
    GameObject player;
    [SerializeField]
    GameObject bullet;
    RaycastHit2D raycast;
    [SerializeField]
    float coolDown = 1;
    private float timer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //raycast = Physics2D.Raycast(transform.position, player.transform.position, Mathf.Infinity);
        RaycastHit2D hit = Physics2D.Raycast(transform.position + transform.up.normalized, transform.up.normalized);
        if (hit.collider != null)
        {
            //Debug.Log(hit.collider.name);
            if(hit.collider.tag == "Player" && timer <= 0)
            {
                audioManager.Instance.MakeShotSound();
                GameObject bulletObject = Instantiate(bullet, transform.position + transform.up.normalized,transform.rotation);
                //bulletObject.GetComponent<BulletScript>().isEnnemiBullet = true ;
                timer = coolDown;
            }
        }
        timer -= Time.deltaTime;
        //Debug.Log(this.name);
        transform.up = player.transform.position - transform.position;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "bullet")
        {
            audioManager.Instance.MakeHurtSound();
            Destroy(gameObject);
            Destroy(collision);
        }
    }
}