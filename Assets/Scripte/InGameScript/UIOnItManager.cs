using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIOnItManager : MonoBehaviour
{
    private BulletManager bulletManager;
    private PlayerController playerController;
    private Transform parentTranform;
    private GameObject ammoGO;
    private GameObject comboGO;
    private TextMeshPro ammoUI;
    private TextMeshPro comboUI;
    private float ammo;
    private float combo;

    private void OnEnable()
    {
        EventManager.StartListening("PuTOnScreenCombo", AddValueOnCombo);
    }

    private void OnDisable()
    {
        EventManager.StopListening("PuTOnScreenCombo", AddValueOnCombo);
    }

    // Start is called before the first frame update
    void Start()
    {
        playerController = GetComponent<PlayerController>();
        parentTranform = GetComponentInParent<Transform>();
        bulletManager = GetComponent<BulletManager>();

        ammoGO = transform.Find("AmmoUI").gameObject;
        comboGO = transform.Find("ComboUI").gameObject;
        comboUI = comboGO.GetComponent<TextMeshPro>();
        ammoUI = ammoGO.GetComponent<TextMeshPro>();
        ammo = GetComponent<BulletManager>().ammo; 

    }

    // Update is called once per frame
    void Update()
    {
        SetInformation();
        FixPosition();
    }

    private void AddValueOnCombo(float obj)
    {
        //Debug.Log("ADDVALUE " + combo);
        combo = obj;
    }


    private void FixPosition()
    {
        
        //The pivot point is set manually
        //Same thing
        //comboUI.transform.eulerAngles = parentTranform.eulerAngles -transform.eulerAngles;
        comboUI.transform.right = transform.position - comboUI.transform.position;
        comboUI.transform.eulerAngles = new Vector3(comboUI.transform.rotation.x, comboUI.transform.rotation.y, 0);
        ammoGO.transform.right = transform.position - ammoGO.transform.position;
        ammoGO.transform.eulerAngles = new Vector3(ammoGO.transform.rotation.x, ammoGO.transform.rotation.y, 0);
    }

    private void SetInformation()
    {
        ammoUI.color = bulletManager.bulletColor;
        if(playerController.haveAmmo == true)
        {
            ammoUI.text = bulletManager.ammo.ToString() + "/" + bulletManager.maxAmmo.ToString();
        }
        else
        {
            ammoUI.text = "Empty";
        }
        if(combo > 1)
        {
            comboUI.text = "x" + combo.ToString();
        }
        else
        {
            comboUI.text = "";
        }
        
    }
}
