using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MainCameraSwitchState : MonoBehaviour
{
    private Animator anim;

    private void OnEnable()
    {
        EventManager.StartListening("SwitchToChapters", chapters);
    }

    private void OnDisable()
    {
        EventManager.StopListening("SwitchToChapters", chapters);
    }

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void chapters(float obj)
    {
        bool state;
        if(obj == 0)
        {
            state = false;
        }
        else
        {
            state = true;
        }
        anim.SetBool("switchToChapter",state);
        Debug.Log("chapters");
    }
}
