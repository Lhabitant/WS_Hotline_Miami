using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControll : MonoBehaviour {

    [SerializeField]
    GameObject focus;
    [SerializeField]
    float zPosition;
    [SerializeField]
    float coeffVisorCamera = 1;
    public Vector3 positionWithoutCursor;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 mousePos = Input.mousePosition;
        //Set the mouse position according to the screen
        Vector3 worldPos = Camera.main.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, - 10.0f)) - focus.transform.position;
        worldPos = worldPos.normalized * coeffVisorCamera;
        transform.position = new Vector3(focus.transform.position.x, focus.transform.position.y, zPosition) + worldPos;
        positionWithoutCursor = transform.position - worldPos;
        //Debug.Log(transform.position);
    }
}
