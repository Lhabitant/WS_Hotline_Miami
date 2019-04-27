using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoContainerScript : MonoBehaviour
{
    
    //Enum is in bullet manager
    public BulletType bulletType = BulletType.Normal;

    public int ammo = 6;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        switch (bulletType)
        {
            case BulletType.Normal:
                {
                    break;
                }
            case BulletType.Rebondissante:
                {
                    break;
                }
            case BulletType.Explosion:
                {
                    break;
                }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            audioManager.Instance.MakeHappySound();
            Destroy(gameObject);
        }

    }
}
