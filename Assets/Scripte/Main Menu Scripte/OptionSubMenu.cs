using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class OptionSubMenu : MonoBehaviour
{
    public GameObject textPosEnd;
    private GameObject controlGO;
    private GameObject visualGO;
    private GameObject soundsGO;

    public float defaultFontSize;
    public float fontSizeMax = 40;
    public Vector3 newPosition;
    public float tLerp;

    // Start is called before the first frame update
    void Start()
    {
        textPosEnd = GameObject.FindWithTag("End Text Position Menu");
        controlGO = transform.Find("Control").gameObject;
        visualGO = transform.Find("Visual").gameObject;
        soundsGO = transform.Find("Sounds").gameObject;

        defaultFontSize = controlGO.GetComponent<TextMeshPro>().fontSize;

        SetAlphaTo0(controlGO);
        SetAlphaTo0(visualGO);
        SetAlphaTo0(soundsGO);
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
        ButtonSystem(controlGO);
        ButtonSystem(visualGO);
        ButtonSystem(soundsGO);
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
        if (button.GetComponent<MouseOnItScript>().mouseOnIt)
        {
            button.GetComponent<TextMeshPro>().fontSize = fontSizeMax;
            if (Input.GetMouseButton(0))
            {
                if (button.name == soundsGO.name)
                {
                    Debug.Log(button.name);
                    EventManager.TriggerEvent("SwitchToSounds", 1);
                    EventManager.TriggerEvent("SwitchSoundsDisplay", 1);
                }
                else if (button.name == controlGO.name)
                {
                    Debug.Log(button.name);
                    EventManager.TriggerEvent("SwitchToInputs", 1);
                }
                else if (button.name == visualGO.name)
                {
                    Debug.Log(button.name);
                    EventManager.TriggerEvent("SwitchToOptions", 1);
                }
            }
        }
        else
        {
            button.GetComponent<TextMeshPro>().fontSize = defaultFontSize;
        }
    }
}
