using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundMenu : MonoBehaviour
{
    //Use the camera to get all state of the camera
    public GameObject mainCamera;
    public Animator cameraAnim;


    private void OnEnable()
    {
        EventManager.StartListening("SwitchSoundsDisplay", SwitchState);
    }

    private void OnDisable()
    {
        EventManager.StartListening("SwitchSoundsDisplay", SwitchState);
    }

    private void SwitchState(float obj)
    {
        if (transform.gameObject.activeSelf)
        {
            transform.gameObject.SetActive(false);
        }
        else
        {
            transform.gameObject.SetActive(true);
        }
       
    }
}
