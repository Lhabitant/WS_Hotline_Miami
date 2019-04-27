using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    public BulletManager bulletManager;
    [SerializeField] GameObject target;
    [SerializeField] float speed = 10f;
    [SerializeField] float knockBack = 1f;
    Rigidbody2D body;
    public bool isMoving = false;
    private bool dead = false;

    private UnityAction someListener;
    //Message System
    private void OnEnable()
    {
        EventManager.StartListening("KillPlayer", SetDead);
    }

    private void OnDisable()
    {
        EventManager.StopListening("KillPlayer", SetDead);
    }


    // Use this for initialization
    void Start ()
    {
        body = GetComponent<Rigidbody2D>();
        bulletManager = GetComponent<BulletManager>();
        //gameObject.transform.Find("canon").GetComponent<GameObject>().GetComponent<BulletManager>();

    }
	
	// Update is called once per frame
	void Update () {
 
        restart();
    }

    private void FixedUpdate()
    {
        if (!dead)
        {
            InputManager();
        }
    }

    private void restart()
    {
        if (Input.GetKey(KeyCode.R) && dead == true)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    void InputManager()
    {
        RotateManager();
        Knockback();
        //Movement();
        OldMovement();
    }

    private void Movement()
    {
        if(Input.GetKey(KeyCode.Z))
        {
            transform.Translate(Vector3.up * speed, Space.World);
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.down * speed , Space.World);
        }
        if (Input.GetKey(KeyCode.Q))
        {
            transform.Translate(Vector3.left * speed, Space.World);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * speed, Space.World);
        }
    }

    private void OldMovement()
    {
        Vector2 Movement = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        Movement.Normalize();
        if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
        {
            body.velocity = Movement * speed; //* Time.deltaTime;
        }
        else { body.velocity = new Vector2(0, 0); }
    }

    private void Knockback()
    {
        if (Input.GetMouseButtonDown(0) && bulletManager.ammo != 0)
        {
            //Debug.Log(-transform.up.normalized * knockBack);
            body.AddForce(-transform.up.normalized * knockBack);

        }
    }

    private void SetDead(float nothing)
    {
        Debug.Log("YOU ARE DEAD");
        dead = true;
    }

    void RotateManager()
    {
        // equivalent at 
        //transform.LookAt(Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y,0)));
        transform.up = target.transform.position - transform.position;

        //transform.eulerAngles += new Vector3(0,0,-90);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "ennemi" || collision.tag =="ennemibullet" )
        {
            SetDead(0);
        }
        else if (collision.tag == "ammocontainer")
        {
            bulletManager.bulletType = collision.GetComponent<AmmoContainerScript>().bulletType;
            bulletManager.loaderBullet = collision.GetComponent<AmmoContainerScript>().ammo;
            bulletManager.ammo = bulletManager.loaderBullet;
        }
    }
}
