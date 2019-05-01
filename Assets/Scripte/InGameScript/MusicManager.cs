using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    AudioSource audioSource;
    private float initialPitch;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        initialPitch = audioSource.pitch;
        DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale != 1)
        {
            audioSource.pitch = Time.timeScale*4;
        }
        else
        {
            audioSource.pitch = initialPitch;
        }
    }
}
