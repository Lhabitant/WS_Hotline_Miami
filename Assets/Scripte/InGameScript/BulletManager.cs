﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BulletType { None, Normal, Rebondissante, Explosion };
public enum WeaponType { None, Pistol, Shotgun, Aka, Uzi};

public class BulletManager : MonoBehaviour {

    [SerializeField]
    GameObject bullet;
    [SerializeField]
    GameObject mainCamera;
    public GameObject punchObject;
    public GameObject weapon;
    public float canonOut = 1;
    private PlayerController playerController;

    [Header("Weapon Information")]
    public BulletType bulletType = BulletType.Normal;
    public WeaponType weaponType = WeaponType.Pistol;
    public Color bulletColor;
    [Header("Ammo Information")]
    public int ammo = 6;
    public int maxAmmo = -1;
    [Header("Color List")]
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
        if (Input.GetMouseButtonDown(0) && ammo > 0  && weaponType == WeaponType.Pistol)
        {
            Pistol();
        }
        else if (Input.GetMouseButtonDown(0) && ammo > 0 && weaponType == WeaponType.Shotgun)
        {
            Shotgun();
        }
        else if (Input.GetMouseButton(0) && ammo > 0 && weaponType == WeaponType.Uzi)
        {
            Uzi();
        }
        else if (Input.GetMouseButton(0) && ammo > 0 && weaponType == WeaponType.Aka)
        {
            Pistol();
        }
        else if (Input.GetMouseButtonDown(0) && ammo == 0)
        {
           Punch();
           playerController.haveAmmo = false;
        }

        if(Input.GetMouseButtonDown(1) && playerController.haveWeapon)
        {
            DropWeapon();
            playerController.haveWeapon = false;
            playerController.haveAmmo = false;
        }
    }

    private void Pistol()
    {
        ammo--;
        audioManager.Instance.MakeShotSound();
        Instantiate(bullet, transform.position + transform.up * canonOut, transform.rotation);
        mainCamera.GetComponent<ShakeBehavior>().TriggerShake();
        playerController.haveAmmo = true;
    }

    private void Shotgun()
    {
        ammo--;
        audioManager.Instance.MakeShotSound();

        //Debug.Log("PAN");
 
        for (int i = 0; i <= 6; i++)
        {
            GameObject test = Instantiate(bullet, transform.position + transform.up * canonOut, transform.rotation);
            BulletScript script = test.GetComponent<BulletScript>();
            script.minValue = -3;
            script.maxValue =  3;
        }

        mainCamera.GetComponent<ShakeBehavior>().TriggerShake();
        playerController.haveAmmo = true;
    }

    private void Uzi()
    {
        ammo--;
        audioManager.Instance.MakeShotSound();


        GameObject test = Instantiate(bullet, transform.position + transform.up * canonOut, transform.rotation);
        BulletScript script = test.GetComponent<BulletScript>();
        script.minValue = -3;
        script.maxValue = 3;
        mainCamera.GetComponent<ShakeBehavior>().TriggerShake();
        playerController.haveAmmo = true;
    }

    private void DropWeapon()
    {
        GameObject test = Instantiate(weapon, transform.position + transform.up * canonOut, transform.rotation);
        WeaponDropedscript weaponData = test.GetComponent<WeaponDropedscript>();
        weaponData.owner = this.gameObject;
        weaponData.myBulletType = this.bulletType;
        weaponData.myWeaponType = this.weaponType;
        weaponData.ammoInside = this.ammo;
        weaponData.maxAmmo = this.maxAmmo;

        bulletType = BulletType.None;
        weaponType = WeaponType.None;
        ammo = 0;
        maxAmmo = 0;
    }

    private void Punch()
    {
        GameObject test = Instantiate(punchObject, transform.position + transform.up, transform.rotation);
        Destroy(test, 0.2f);
    }
}
