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
        EventManager.StartListening("SwitchToChapters", Chapters);
        EventManager.StartListening("SwitchToOptions", Options);
    }

    private void OnDisable()
    {
        EventManager.StopListening("SwitchToChapters", Chapters);
        EventManager.StopListening("SwitchToOptions", Options);
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

    private void Chapters(float obj)
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

    private void Options(float obj)
    {
        bool state;
        if (obj == 0)
        {
            state = false;
        }
        else
        {
            state = true;
        }
        anim.SetBool("switchToOptions", state);
        Debug.Log("options");
    }
}
