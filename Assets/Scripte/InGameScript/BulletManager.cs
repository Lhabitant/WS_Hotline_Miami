using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BulletType { Normal, Rebondissante, Explosion };

public class BulletManager : MonoBehaviour {

    [SerializeField]
    GameObject bullet;
    [SerializeField]
    GameObject mainCamera;
    public GameObject punchObject;
    public GameObject weapon;
    [HideInInspector]
    public int loaderBullet = 0;
    public int ammo = 6;
    public int maxAmmo = -1;
    public float canonOut = 1;
    private PlayerController playerController;

    // Bullet Type
    public BulletType bulletType = BulletType.Normal;
    [HideInInspector]
    public Color bulletColor;
    //COLOR LIST
    public Color NormalBulletC;
    public Color BouncingBulletC;
    public Color ExplosionBulletC;
    

    // Use this for initialization
    void Start ()
    {
        playerController = GetComponent<PlayerController>();
	}
	
	// Update is called once per frame
	void Update () {
        shoot();

        switch (bulletType)
        {
            case BulletType.Normal:
                {
                    bulletColor = NormalBulletC;
                    break;
                }
            case BulletType.Rebondissante:
                {
                    bulletColor = BouncingBulletC;
                    break;
                }
            case BulletType.Explosion :
                {
                    bulletColor = ExplosionBulletC;
                    break;
                }
        }
	}

    private void shoot()
    {
        if (Input.GetMouseButtonDown(0) && ammo > 0 )
        {
            ammo--;
            //Debug.Log("PAN");
            /*
            Vector3 euler = transform.eulerAngles;
            euler.z = Random.Range(0f, 360f);
            transform.eulerAngles = euler;
            */
            audioManager.Instance.MakeShotSound();
            /*
            for (int i = 0; i <= 10; i++)
            {
                Instantiate(bullet, transform.position, transform.rotation);
            }
            */
            Instantiate(bullet, transform.position + transform.up * canonOut, transform.rotation);
            mainCamera.GetComponent<ShakeBehavior>().TriggerShake();
            playerController.haveAmmo = true;
        }
        else if (Input.GetMouseButtonDown(0) && ammo == 0)
        {
           Punch();
           playerController.haveAmmo = false;
        }

        if(Input.GetMouseButtonDown(1))
        {
            DropWeapon();
        }
    }

    private void DropWeapon()
    {
        GameObject test = Instantiate(weapon, transform.position + transform.up, transform.rotation);
        test.GetComponent<WeaponDropedscript>().owner = this.gameObject;
    }

    private void Punch()
    {
        GameObject test = Instantiate(weapon, transform.position + transform.up, transform.rotation);
        Destroy(test, 0.2f);
    }
}
