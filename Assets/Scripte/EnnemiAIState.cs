using Pathfinding;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemiAIState : MonoBehaviour
{
    private AIPath AIScript;
    public GameObject player;
    private float timer;
    public float timeDuration = 2.0f;

    // Start is called before the first frame update
    void Start()
    {
        AIScript = GetComponent<AIPath>();
        AIScript.enabled = false;

    }

    // Update is called once per frame
    void Update()
    {
        AimPlayer();
    }

    private void AimPlayer()
    {
        Debug.Log(timer);
        RaycastHit2D hit = Physics2D.Raycast(transform.position + transform.up.normalized, transform.up.normalized);
        if (hit.collider != null)
        {
            
            if (hit.collider.tag == "Player" || timer > 0)
            {
                AIScript.enabled = true;
                timer = timeDuration;
            }
            else
            {
                AIScript.enabled = false;
            }
        }
        timer -= Time.deltaTime;
        if(timer < 0)
        {
            transform.up = player.transform.position - transform.position;
        }
       
    }
}
