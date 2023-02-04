using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioMusicPlaylist : MonoBehaviour
{
    public AudioClip[] musicClips;
    private int currentClip = 0;
    private AudioSource audioSource;

    private void Awake()
    {

    }

    // Start is called before the first frame update
    void Start()
    {
        audioSource = AudioManager.Instance.musicSource;
        AudioManager.Instance.musicSource.clip = musicClips[currentClip];
        AudioManager.Instance.musicSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (!AudioManager.Instance.musicSource.isPlaying)
        {
            currentClip = (currentClip + 1) % musicClips.Length;
            AudioManager.Instance.musicSource.clip = musicClips[currentClip];
            AudioManager.Instance.musicSource.Play();
        }
    }
}
