using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComboManager : MonoBehaviour
{
    public int combo = 0;
    public float timer;
    public int timeDuration = 2;
    private void OnEnable()
    {
        EventManager.StartListening("KillEnnemi", IncreaseCombo);
    }

    private void OnDisable()
    {
        EventManager.StopListening("KillEnnemi", IncreaseCombo);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }



    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if(timer <= 0)
        {
            combo = 0;
            timer = 0;
            EventManager.TriggerEvent("PuTOnScreenCombo", combo);
        }

    }

    private void IncreaseCombo(float comboValue)
    {
        //Debug.Log("olol " + combo);
        combo += (int)comboValue;
        timer = timeDuration;
        EventManager.TriggerEvent("PuTOnScreenCombo", combo);
        EventManager.TriggerEvent("AddComboScore", combo);
    }
}
