using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using TMPro;

public class SoundScript : MonoBehaviour
{
    public TextMeshProUGUI masterTExt, soundFxText, musicText;
    public AudioMixer mixer;
    public GameObject SoundPanel;
    public Slider masterSlider, soundfxSlider, audioSlider;
    void Start()
    {
        if (PlayerPrefs.HasKey("Sfx"))
        {
            PlayerPrefs.SetFloat("Master", masterSlider.value);
            PlayerPrefs.SetFloat("Sfx", PlayerPrefs.GetFloat("Sfx"));
            PlayerPrefs.SetFloat("Audio", audioSlider.value);

            SliderValues();
        }
        else
        {
            SliderValues();
        }

        Debug.Log(" masterSlider.value==" + masterSlider.value + "soundfxSlider.value==" + soundfxSlider.value + "audioSlider.value==" + audioSlider.value);
    }



    public void  SliderValues()
    {
        masterSlider.value = PlayerPrefs.GetFloat("Master");
        soundfxSlider.value = PlayerPrefs.GetFloat("Sfx");
        audioSlider.value = PlayerPrefs.GetFloat("Audio");
    }


    public void UpdateMastervalue()
    {
        mixer.SetFloat("Master", masterSlider.value);
        PlayerPrefs.SetFloat("Master", masterSlider.value);
    }
    public void UpdateSfx()
    {
        mixer.SetFloat("Sfx", soundfxSlider.value);
        PlayerPrefs.SetFloat("Sfx", soundfxSlider.value);
    }

    public void UpdateAudio()
    {
        mixer.SetFloat("Audio", audioSlider.value);
        PlayerPrefs.SetFloat("Audio", audioSlider.value);
    }


    private void Update()
    {
       
    }
}
