using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class KeyBindScript : MonoBehaviour
{
    private Dictionary<string, KeyCode> keys = new Dictionary<string, KeyCode>();

    public TextMeshPro up, left, down, right;

    private GameObject currentKey;
    // Start is called before the first frame update
    void Start()
    {
        keys.Add("Up",(KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Up","Z")));
        keys.Add("Down", (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Down", "S")));
        keys.Add("Left", (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Right", "Q")));
        keys.Add("Right", (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Left", "D")));

        up.text = keys["Up"].ToString();
        down.text = keys["Down"].ToString();
        left.text = keys["Left"].ToString();
        right.text = keys["Right"].ToString();

    }
/*
    private void OnEnable()
    {
        EventManager.StartListening("KillPlayer", SetDead);
    }

    private void OnDisable()
    {
        EventManager.StopListening("KillPlayer", SetDead);
    }
*/

    // Update is called once per frame
    void Update()
    {
        //Input.GetAxis("Horizontal")
        if (Input.GetAxis("Vertical") < 0)
        {
            Debug.Log("Up");
        }
        if (Input.GetKeyDown(keys["Down"]))
        {
            Debug.Log("Down");
        }
        if (Input.GetKeyDown(keys["Left"]))
        {
            Debug.Log("Left");
        }
        if (Input.GetKeyDown(keys["Right"]))
        {
            Debug.Log("Right");
        }
    }

    //OnGUI()
    public void OnGUI()
    {
        if(currentKey != null)
        {
            Event e = Event.current;
            if(e.isKey)
            {
                keys[currentKey.name] = e.keyCode;
                currentKey.GetComponent<TextMeshPro>().text = e.keyCode.ToString();
                currentKey = null;

                Debug.Log(e.keyCode.ToString());
            }
        }
        
    }

    public void ChangeKey(GameObject clicked)
    {

        currentKey = clicked;
        SaveKeys();
    }

    public void SaveKeys()
    {
        foreach( var key in keys)
        {
            PlayerPrefs.SetString(key.Key, key.Value.ToString());
        }
        PlayerPrefs.Save();
        Debug.Log("Save");
    }
}
