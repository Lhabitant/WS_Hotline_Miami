using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    public float slowTimer;
    private bool isMoving = false;
    private Rigidbody2D body;
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

   
    private void FixedUpdate()
    {
        if (GetComponent<Rigidbody2D>().velocity.magnitude == 0)
        {
            isMoving = false;
        }
        else { isMoving = true; }
        slowMotion();

    }

    private void slowMotion()
    {
        if (isMoving)
        {
            Time.timeScale = 1;
        }
        else
        {
            Time.timeScale = slowTimer;
        }
        Time.fixedDeltaTime = 0.02f * Time.timeScale;
    }
}
