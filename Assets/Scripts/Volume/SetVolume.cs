using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SetVolume : MonoBehaviour
{
    [SerializeField] private AudioMixer audioMixer;
    public void SetVol(float sliderValue)
    {
        audioMixer.SetFloat("MusicVol", Mathf.Log10(sliderValue) * 20);
        audioMixer.SetFloat("SFXVol", Mathf.Log10(sliderValue) * 20);

    }


}
