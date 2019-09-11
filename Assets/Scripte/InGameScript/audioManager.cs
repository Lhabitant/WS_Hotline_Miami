using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class audioManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static audioManager Instance;
    public AudioSource audioSrc;

    public AudioClip explosionSound;
    public AudioClip ShotSound1;
    public AudioClip ShotSound2;
    public AudioClip ShotSound3;
    public AudioClip ShotSound4;
    public AudioClip ShotSound5;
    public AudioClip enemyhurtSound1;
    public AudioClip enemyhurtSound2;
    public AudioClip enemyhurtSound3;
    public AudioClip playerHappy1;
    public AudioClip playerHappy2;
    public AudioClip playerHappy3;

    


    void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("Multiple instances of SoundEffectsHelper!");
        }
        Instance = this;
        audioSrc = GetComponent<AudioSource>();
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MakeShotSound()
    {
        int random = Random.Range(1, 5);
        switch (random)
        {
            case 1:
                {
                    MakeSound(ShotSound1);
                    break;
                }
            case 2:
                {
                    MakeSound(ShotSound2);
                    break;
                }
            case 3:
                {
                    MakeSound(ShotSound3);
                    break;
                }
            case 4:
                {
                    MakeSound(ShotSound4);
                    break;
                }
            case 5:
                {
                    MakeSound(ShotSound5);
                    break;
                }
            default:
                print("No sound found");
                break;
        }
    }

    public void MakeHurtSound()
    {
        int random = Random.Range(1, 3);
        switch (random)
        {
            case 1:
                {
                    MakeSound(enemyhurtSound1);
                    break;
                }
            case 2:
                {
                    MakeSound(enemyhurtSound2);
                    break;
                }
            case 3:
                {
                    MakeSound(enemyhurtSound3);
                    break;
                }
            default:
            print("No sound found");
            break;
        }
    }

    public void MakeHappySound()
    {
        int random = Random.Range(1, 3);
        switch (random)
        {
            case 1:
                {
                    MakeSound(playerHappy1);
                    break;
                }
            case 2:
                {
                    MakeSound(playerHappy2);
                    break;
                }
            case 3:
                {
                    MakeSound(playerHappy3);
                    break;
                }
            default:
                print("No sound found");
                break;
        }
    }

    private void MakeSound(AudioClip originalClip)
    {

        //AudioSource.PlayClipAtPoint(originalClip, transform.position);
        audioSrc.PlayOneShot(originalClip);
    }
}
