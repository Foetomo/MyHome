using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
    public Sound[] musicSounds, sfxSounds;
    public AudioSource musicSource, sfxSource;
    public GameObject iconMuteOn, iconMuteOff;
    //FootstepSystem fs;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        int isMutedMusic = PlayerPrefs.GetInt("MuteMusic");
        musicSource.mute = (isMutedMusic == 1);

        int isMutedSfx = PlayerPrefs.GetInt("MuteSFX");
        sfxSource.mute = (isMutedSfx == 1);

    }

    private void Update()
    {
        //fs = FindObjectOfType<FootstepSystem>();

        PlayerPrefs.SetInt("MuteMusic", musicSource.mute ? 1 : 0);
        PlayerPrefs.SetInt("MuteSFX", sfxSource.mute ? 1 : 0);
    }

    public void PlayMusic(string nama)
    {
        Sound s = Array.Find(musicSounds, x => x.nama == nama);

        if (s == null)
        {
            Debug.Log("Sound Not Found");
        }
        else
        {
            musicSource.clip = s.clip;
            musicSource.Play();
        }
    }

    public void PlaySFX(string nama)
    {
        Sound s = Array.Find(sfxSounds, x => x.nama == nama);

        if (s == null)
        {
            Debug.Log("Sound Not Found");
        }
        else
        {
            sfxSource.clip = s.clip;
            sfxSource.Play();
        }
    }

    public void ToggleMusic()
    {
        musicSource.mute = !musicSource.mute;
    }

    public void ToggleSFX()
    {
        sfxSource.mute = !sfxSource.mute;
    }

    public void MusicVolume(float volume)
    {
        musicSource.volume = volume;
    }

    public void SFXVolume(float volume)
    {
        sfxSource.volume = volume;
    }

}
