using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    public AudioSource levelMusic, BossMusic, LooseMusic, WinMusic;
    public AudioSource[] soundfx;


    private void Awake()
    {
        if (instance==null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    void Start()
    {
        levelMusic.Play();
    }

    public void StopAllMusic()
    {
        levelMusic.Stop();
        BossMusic.Stop();
        LooseMusic.Stop();
        WinMusic.Stop();
    }
    

    public void LevelMusic()
    {
        levelMusic.Stop();
        levelMusic.Play();

    }

    public void BossMusicFunc()
    {
        BossMusic.Stop();
        BossMusic.Play();
    }


    public void LooseMusicFunc()
    {
        levelMusic.Stop();
        levelMusic.Play();
    }



    public void winMusicFunc()
    {
        WinMusic.Stop();
        WinMusic.Play();
    }
    public void SfxFunc(int sfx)
    {
        soundfx[sfx].Stop();
        soundfx[sfx].Play();
    }

}
