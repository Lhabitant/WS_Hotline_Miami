using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyOnLoad : MonoBehaviour
{    
    private GameObject[] music;

   void Start()
   {
        music = GameObject.FindGameObjectsWithTag("musicsource");
        Destroy(music[1]);
   }


   void Awake()
   {
         //Debug.Log("TEST");
         DontDestroyOnLoad(transform.gameObject);
   }
}
