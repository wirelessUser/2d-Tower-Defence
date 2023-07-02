using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public static AudioController instance;
    public AudioClip[] audioArray;
    public AudioSource audioSource;
   void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

   

    public void PlayFx()
    {
        audioSource.clip = audioArray[0];
        audioSource.Play();
    }
}
