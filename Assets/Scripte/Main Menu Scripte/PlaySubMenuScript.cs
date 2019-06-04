using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class PlaySubMenuScript : MonoBehaviour
{
    public GameObject textPosEnd;
    private GameObject newGameGO;
    private GameObject continueGO;
    private GameObject chaptersGO;

    public float defaultFontSize;
    public float fontSizeMax = 40;
    public Vector3 newPosition;
    public float tLerp;

    // Start is called before the first frame update
    void Start()
    {
        textPosEnd = GameObject.FindWithTag("End Text Position Menu");
        newGameGO = transform.Find("New Game").gameObject;
        continueGO = transform.Find("Continue").gameObject;
        chaptersGO = transform.Find("Chapters").gameObject;
 
        defaultFontSize = newGameGO.GetComponent<TextMeshPro>().fontSize;

        SetAlphaTo0(newGameGO);
        SetAlphaTo0(continueGO);
        SetAlphaTo0(chaptersGO);
    }

    private void SetAlphaTo0(GameObject button)
    {
        Color32 color = button.GetComponent<TextMeshPro>().faceColor;
        color = new Color32(color.r, color.g, color.b, 0);
        button.GetComponent<TextMeshPro>().faceColor = color;
    }


    // Update is called once per frame
    void Update()
    {
        SmootlhyAppear();
        ButtonSystem(newGameGO);
        ButtonSystem(continueGO);
        ButtonSystem(chaptersGO);
    }

    private void SmootlhyAppear()
    {
        /*
        SmoothlyAlpha(newGameGO);
        SmoothlyAlpha(continueGO);
        SmoothlyAlpha(chaptersGO);
        */
        transform.position = Vector3.Lerp(transform.position, textPosEnd.transform.position, tLerp);
    }

    private void SmoothlyAlpha(GameObject button)
    {
        Color32 localFaceColor = button.GetComponent<TextMeshPro>().faceColor;
        localFaceColor = new Color32(localFaceColor.r, localFaceColor.g, localFaceColor.b, 0);
    }

    private void ButtonSystem(GameObject button)
    {
        if(button.GetComponent<MouseOnItScript>().mouseOnIt)
        {
            button.GetComponent<TextMeshPro>().fontSize = fontSizeMax;
            if(Input.GetMouseButton(0))
            {
                if (button.name == chaptersGO.name)
                {
                    Debug.Log(button.name);
                    EventManager.TriggerEvent("SwitchToChapters", 1);
                }
                else if (button.name == newGameGO.name)
                {
                    SceneManager.LoadScene("SampleScene");
                }
                else if (button.name == continueGO.name)
                {
                    SceneManager.LoadScene("SampleScene");
                }
            }
        }
        else
        {
            button.GetComponent<TextMeshPro>().fontSize = defaultFontSize;
        }
    }
}
