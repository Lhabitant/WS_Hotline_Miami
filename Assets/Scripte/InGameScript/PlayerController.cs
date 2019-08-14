using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    public PlayerData playerData;

    public BulletManager bulletManager;
    [SerializeField] GameObject target;
    [SerializeField] float speed = 10f;
    [SerializeField] float knockBack = 1f;
    public Rigidbody2D body;
    [Header("Information Settings")]
    public bool isMoving = false;
    private bool dead = false;
    public bool haveWeapon = false;
    public bool haveAmmo = false;

    [Header("Collider Settings")]
    public Collider2D hitCollider;
    public Collider2D PunchCollider;
    public Collider2D collider3;

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
        hitCollider = GetComponent<BoxCollider2D>();
        body = GetComponent<Rigidbody2D>();
        bulletManager = GetComponent<BulletManager>();
        

    }
	
	// Update is called once per frame
	void Update () {
 
        restart();
        Knockback();
    }

    private void FixedUpdate()
    {
        if (!dead)
        {
            InputManager();
        }
        AmmoSystem();
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
       
        Movement();
        OldMovement();
    }

    private void Movement()
    {
        Vector2 Movement = new Vector2(0, 0);
        if(Input.GetButton("Up"))
        {
            Movement = Vector2.up;
        }
        if (Input.GetButton("Down"))
        {
            Movement = Vector2.down;
        }
        if (Input.GetButton("Left"))
        {
            Movement = Vector2.left;
        }
        if (Input.GetButton("Right"))
        {
            Movement = Vector2.right;
        }

        body.velocity = Movement.normalized * playerData.speed;
    }

    private void OldMovement()
    {
        Vector2 Movement = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        Movement.Normalize();
        if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
        {
            body.velocity = Movement * playerData.speed;// * Time.deltaTime;
            isMoving = true;
        }
        else
        {
            body.velocity = new Vector2(0, 0);
            isMoving = false;
        }
    }

    private void AmmoSystem()
    {
        if (haveAmmo == false)
        {
            bulletManager.ammo = 0;
        }
        if(GetComponent<BulletManager>().ammo == 0)
        {
            haveAmmo = false;
        }
    }

    private void Knockback()
    {
        if (Input.GetMouseButtonDown(0) && haveWeapon & haveAmmo)
        {
            //Debug.Log(-transform.up.normalized * knockBack);

            Debug.Log("KNOCK");
            body.AddForce(-transform.up.normalized * playerData.knockBack, ForceMode2D.Force);

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
       
        /*
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = new Vector2(mousePosition.x - transform.position.x, mousePosition.y - transform.position.y);
        transform.up = direction;
        */
        /*
        Vector3 mouse = Input.mousePosition;
        Vector3 test = new Vector3(mouse.x, mouse.y, transform.position.y);
        Vector3 mouseWorld = Camera.main.ScreenToWorldPoint(test);
        transform.up = mouseWorld - transform.position;
        transform.eulerAngles = new Vector3(0,0,transform.eulerAngles.z);
        */
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (GetComponent<BoxCollider2D>().GetType() == typeof(BoxCollider2D))
        {
            if (collision.tag == "ennemi" || collision.tag == "ennemibullet")
            {
                SetDead(0);
            }
            else if (collision.tag == "ammocontainer")
            {
                bulletManager.weaponType = collision.GetComponent<AmmoContainerScript>().weaponType;
                bulletManager.bulletType = collision.GetComponent<AmmoContainerScript>().bulletType;
                bulletManager.ammo = collision.GetComponent<AmmoContainerScript>().ammo;
                bulletManager.maxAmmo = collision.GetComponent<AmmoContainerScript>().ammo;
                haveAmmo = true;
                haveWeapon = true;
            }
            else if ((collision.tag == "weapon") && (haveWeapon == false)) 
            {
                WeaponDropedscript weaponDroped = collision.gameObject.GetComponent<WeaponDropedscript>();
                EventManager.TriggerEvent("GetWeapon", 1);
                haveWeapon = true;
                if(weaponDroped.ammoInside > 0)
                {
                    haveAmmo = true;
                }
                bulletManager.bulletType = weaponDroped.myBulletType;
                bulletManager.weaponType = weaponDroped.myWeaponType;
                bulletManager.ammo = weaponDroped.ammoInside;
                bulletManager.maxAmmo = weaponDroped.maxAmmo;

                Destroy(collision.gameObject);
            }
        }

    }
}
