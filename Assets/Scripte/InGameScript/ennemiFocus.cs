using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ennemiFocus : MonoBehaviour
{
    private Rigidbody2D body;
    private Collider2D meetArea;
    private Vector3 positionOrigin;
    [SerializeField]
    int stateRoom = 0;
    [SerializeField]
    GameObject room;
    [SerializeField]
    GameObject player;
    [SerializeField]
    float speed = 20;
    [SerializeField]
    float Attakspeed = 50;
    [SerializeField]
    GameObject deathParticle;


    // Start is called before the first frame update
    void Start()
    {
        meetArea = GetComponent<CircleCollider2D>();
        body= GetComponent<Rigidbody2D>();
        positionOrigin = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {
        Vector3 posRoomX1Y1 = new Vector3(room.transform.position.x - room.transform.localScale.x / 2, room.transform.position.y - room.transform.localScale.y / 2, 0f);
        Vector3 posRoomX2Y2 = new Vector3(room.transform.position.x + room.transform.localScale.x / 2, room.transform.position.y + room.transform.localScale.y / 2, 0f);
        Passivemove(posRoomX1Y1, posRoomX2Y2);
        AttackMove(posRoomX1Y1, posRoomX2Y2);
       

    }

    private void AttackMove(Vector3 posRoomX1Y1, Vector3 posRoomX2Y2)
    {
        Vector3 playPos = player.transform.position;
        if ((playPos.x > posRoomX1Y1.x && playPos.x < posRoomX2Y2.x) && ((playPos.y > posRoomX1Y1.y && playPos.y < posRoomX2Y2.y)))
        {
           // stateRoom = -1;
            Vector3 smoothedDelta = Vector3.MoveTowards(transform.position, playPos, Time.fixedDeltaTime * Attakspeed);
            body.MovePosition(smoothedDelta);
        }
    }

    private void Passivemove(Vector3 posRoomX1Y1, Vector3 posRoomX2Y2)
    {
        if (stateRoom == 0)
        {
            Vector3 smoothedDelta = Vector3.MoveTowards(transform.position, posRoomX1Y1, Time.fixedDeltaTime * speed);
            body.MovePosition(smoothedDelta);
            if (transform.position == posRoomX1Y1)
            {
                stateRoom = 1;
            }
        }
        else if (stateRoom == 1)
        {
            Vector3 smoothedDelta = Vector3.MoveTowards(transform.position, posRoomX2Y2, Time.fixedDeltaTime * speed);
            body.MovePosition(smoothedDelta);
            if (transform.position == posRoomX2Y2)
            {
                stateRoom = 0;
            }
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "bullet" || collision.tag == "punch")
        {
            Debug.Log("ENNEMI KILL");
            //GetComponent<Collider2D>().enabled = false;
            Instantiate(deathParticle, transform.position, transform.rotation);
            audioManager.Instance.MakeHurtSound();
            Destroy(gameObject);
            EventManager.TriggerEvent("KillEnnemi", 1);
            EventManager.TriggerEvent("AddScorePoint", 100);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.GetType() == typeof(BoxCollider2D))
        {
            //
        }
        else if (collision.collider.GetType() == typeof(CircleCollider2D))
        {
            // do stuff only for the circle collider
        }
    }
}
