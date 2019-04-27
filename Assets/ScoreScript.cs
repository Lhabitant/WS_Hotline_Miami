using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class ScoreScript : MonoBehaviour
{
    public float score = 0;
    private float combo = 0;
    private TextMeshPro textMesh;

    private void OnEnable()
    {
        EventManager.StartListening("AddScorePoint", AddScorePoint);
        //EventManager.StartListening("PuTOnScreenCombo", AddCombo);
        EventManager.StartListening("AddComboScore", AddCombo);
    }



    private void OnDisable()
    {
        EventManager.StopListening("AddScorePoint", AddScorePoint);
        //EventManager.StopListening("PuTOnScreenCombo", AddCombo);
        EventManager.StopListening("AddComboScore", AddCombo);
    }


    // Start is called before the first frame update
    void Start()
    {
        textMesh =GetComponent<TextMeshPro>();
    }

    // Update is called once per frame
    void Update()
    {
        textMesh.text = "Score : " + score.ToString();
    }

    private void AddScorePoint(float obj)
    {
        Debug.Log("WE DISPLAY COMBO");
        if (combo >0)
        {
            score += (obj*combo);
        }
        else
        {
            score += obj;
        }
        
    }

    private void AddCombo(float obj)
    {
        Debug.Log("WE ADD COMBO");
        combo = obj;
    }
}
