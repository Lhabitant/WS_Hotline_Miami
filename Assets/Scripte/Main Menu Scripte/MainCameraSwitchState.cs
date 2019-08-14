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
        EventManager.StartListening("SwitchToInputs", Inputs);
        EventManager.StartListening("SwitchToSounds", Sounds); 
    }

    private void OnDisable()
    {
        EventManager.StopListening("SwitchToChapters", Chapters);
        EventManager.StopListening("SwitchToInputs", Inputs);
        EventManager.StartListening("SwitchToSounds", Sounds);
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

    private void Inputs(float obj)
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
        anim.SetBool("switchToInputs", state);
        Debug.Log("Input options");
    }

    private void Sounds(float obj)
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
        anim.SetBool("switchToSounds", state);
        Debug.Log("Sounds options");
    }
}
