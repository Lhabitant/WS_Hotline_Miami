using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AudioSubMenu : MonoBehaviour
{
    private GameObject backGO;
    private float defaultFontSize;
    public float fontSizeMax = 30;

    // Start is called before the first frame update
    void Start()
    {
        backGO = transform.Find("Back").gameObject;

        defaultFontSize = backGO.GetComponent<TextMeshPro>().fontSize;
    }

    // Update is called once per frame
    void Update()
    {
        ButtonSystem(backGO);
    }


    private void ButtonSystem(GameObject button)
    {
        if (button.GetComponent<MouseOnItScript>().mouseOnIt)
        {
            button.GetComponent<TextMeshPro>().fontSize = fontSizeMax;
            if (Input.GetMouseButton(0))
            {
                if (button.name == backGO.name)
                {
                    Debug.Log(button.name);
                    EventManager.TriggerEvent("SwitchToSounds", 0);
                }
            }
        }
        else
        {
            button.GetComponent<TextMeshPro>().fontSize = defaultFontSize;
        }
    }
}
