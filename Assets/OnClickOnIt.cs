using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class OnClickOnIt : MonoBehaviour
{
    private TextMeshPro textMesh;
    public GameObject keyBinding;
    public Color32 neutralColor;
    public Color32 activeColor;

    // Start is called before the first frame update
    void Start()
    {
        textMesh = GetComponent<TextMeshPro>();
        textMesh.color = neutralColor;
        keyBinding = transform.parent.parent.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if(GetComponent<MouseOnItScript>().mouseOnIt)
        {
            if(Input.GetButtonDown("Fire1"))
            {
                Debug.Log(textMesh.text);
                //EventManager.TriggerEvent("KillEnnemi", 1);
                keyBinding.GetComponent<KeyBindScript>().ChangeKey(this.gameObject);
                textMesh.color = activeColor;
            }
        }
    }
}
