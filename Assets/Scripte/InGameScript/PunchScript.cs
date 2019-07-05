using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PunchScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "ennemi")
        {
            Destroy(this.gameObject);
            //Debug.Log("qmhxomihs,hsuhfz");
        }
        GetComponent<BoxCollider2D>().enabled = false;
    }
}
