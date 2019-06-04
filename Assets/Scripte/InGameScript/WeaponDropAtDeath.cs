using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponDropAtDeath : MonoBehaviour
{
    public GameObject weapon;
    public EnnemiShootScript ennemiShootScript;
    // Start is called before the first frame update
    void Start()
    {
         ennemiShootScript = GetComponent<EnnemiShootScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetDataInWeapon()
    {
        GameObject test = Instantiate(weapon, transform.position + transform.up, transform.rotation);
        WeaponDropedscript weaponData = test.GetComponent<WeaponDropedscript>();
        weaponData.owner = this.gameObject;
        weaponData.myBulletType = ennemiShootScript.myBulletType;
        weaponData.myWeaponType = ennemiShootScript.myWeaponType;
        weaponData.ammoInside = ennemiShootScript.ammo;
        weaponData.maxAmmo = ennemiShootScript.maxAmmo;
    }
}
