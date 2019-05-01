using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisorController : MonoBehaviour {

    [SerializeField] Camera cam;
    public Rigidbody2D body;
    // Use this for initialization
    void Start () {
        body = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        InputManager();
	}

    void InputManager()
    {
        Vector3 mousePos = Input.mousePosition;
        //Set the mouse position according to the screen
        Vector3 worldPos = Camera.main.ScreenToWorldPoint( mousePos);

        body.position = new Vector3(worldPos.x,worldPos.y,0);
       
        //Debug.Log("transPos " + transform.position + "bodyPos " + body.position);
    }
}
