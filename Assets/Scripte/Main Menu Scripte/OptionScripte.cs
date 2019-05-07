using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class OptionScripte : MonoBehaviour
{
    public bool mouseOnIt = false;
    public bool clicked = false;
    public float fontSizeMax = 50;
    private float defaultFontSize;
    private TextMeshPro TextMesh;
    public GameObject SubMenu;
    private GameObject submenu;
    private GameObject textPos;
    private bool isInstantiateOnce = false;
    static ButtonClick buttonHighLight = ButtonClick.None;

    // Start is called before the first frame update
    void Start()
    {
        TextMesh = GetComponent<TextMeshPro>();
        textPos = GameObject.FindWithTag("Respawn");
        defaultFontSize = TextMesh.fontSize;
    }

    // Update is called once per frame
    void Update()
    {
        ActivateSubMenu();
        ButtonSystem();
    }

    private void ActivateSubMenu()
    {
        if (clicked == true && isInstantiateOnce == false)
        {
            submenu = Instantiate(SubMenu, textPos.transform.position, textPos.transform.rotation);
            isInstantiateOnce = true;
        }
        else if (SubMenu != null && clicked == false)
        {
            Destroy(submenu);
            isInstantiateOnce = false;
        }
    }

    private void ButtonSystem()
    {
        if (mouseOnIt || clicked == true) //&& buttonHighLight == (ButtonClick)System.Enum.Parse(typeof(ButtonClick), this.name)))
        {
            TextMesh.fontSize = fontSizeMax;
            if (Input.GetMouseButtonDown(0))
            {
                if (clicked == false)
                {
                    clicked = true;
                    //Convert the name of the object to an enum
                    buttonHighLight = (ButtonClick)System.Enum.Parse(typeof(ButtonClick), this.name);
                }
                else
                {
                    clicked = false;
                    buttonHighLight = ButtonClick.None;
                }
                //Debug.Log(buttonHighLight);
            }
        }
        if (!mouseOnIt && Input.GetMouseButtonDown(0))
        {
            TextMesh.fontSize = defaultFontSize;
            buttonHighLight = ButtonClick.None;
            Debug.Log(buttonHighLight);
        }
    }

    private void OnMouseOver()
    {
        mouseOnIt = true;
    }

    private void OnMouseExit()
    {
        mouseOnIt = false;
        TextMesh.fontSize = defaultFontSize;
    }
}
