using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SetVolume : MonoBehaviour
{
    public AudioMixer mixer;
    public string channelName = "default";
    public float logValue;

    public void SetLevelMusic(float sliderValue)
    {
        mixer.SetFloat(channelName, Mathf.Log10(sliderValue) * logValue);
    }
}
