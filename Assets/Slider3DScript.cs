using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slider3DScript : MonoBehaviour
{
    public GameObject barre;
    public GameObject buttonSlider;

    // Start is called before the first frame update
    void Start()
    {
        //barre = transform.Find("Cube").gameObject;
       //buttonSlider = transform.Find("Cylinder").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        Slide();

        Vector3 mousePos = Input.mousePosition;
        //Set the mouse position according to the screen
        Vector3 worldPos = Camera.main.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, Camera.main.nearClipPlane));
        //Debug.Log(worldPos);
    }

    
    private void Slide()
    {
        if (buttonSlider.GetComponent<MouseOnItScript>().mouseOnIt && Input.GetMouseButton(0))
        {
            Vector3 mousePos = Input.mousePosition;
            //Set the mouse position according to the screen
            Vector3 worldPos = Camera.main.ScreenToWorldPoint( new Vector3(mousePos.x, mousePos.y,Camera.main.nearClipPlane));

            buttonSlider.transform.position = new Vector3(worldPos.x, buttonSlider.transform.position.y, buttonSlider.transform.position.z);
        }
    }
}
