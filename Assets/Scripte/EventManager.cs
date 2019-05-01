using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventManager : MonoBehaviour
{

    private Dictionary <string, Action<float>> eventDictionary;

    public static EventManager eventManager;

    public static EventManager instance
    {
        get
        {
            if(!eventManager)
            {
                eventManager = FindObjectOfType(typeof(EventManager)) as EventManager;
                if(!eventManager)
                {
                    Debug.LogError("There need to be one active EventManager Script on a GameObject in your scene ! ");

                }
                else
                {
                    eventManager.Init();
                }
            }
        return eventManager;
        }
    }

    void Init()
    {
        if(eventDictionary == null)
        {
            eventDictionary = new Dictionary<string, Action<float>>();
            Debug.Log("Event system activated");
        }
    }

    public static void StartListening(string eventName, Action<float> listener)
    {
        Action<float> thisEvent = null;
        if(instance.eventDictionary.TryGetValue(eventName, out thisEvent))
        {
            thisEvent += listener;
        }
        else
        {
            thisEvent += listener;
            instance.eventDictionary.Add(eventName, thisEvent);
        }
    }

    public static void StopListening(string eventName, Action<float> listener)
    {
        if (eventManager == null) return;
        Action<float> thisEvent = null;
        if(instance.eventDictionary.TryGetValue(eventName, out thisEvent))
        {
            thisEvent+= listener;
        }
    }

    public static void TriggerEvent(string eventName, float h)
    {
        Action<float> thisEvent = null;
        if(instance.eventDictionary.TryGetValue(eventName, out thisEvent))
        {
            thisEvent.Invoke(h);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
