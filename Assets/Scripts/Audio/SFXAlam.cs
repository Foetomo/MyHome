using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXAlam : MonoBehaviour
{
    public static SFXAlam Instance;
    public AudioClip[] soundAlam;
    public AudioSource audioSourceAlam;
    private int currentSFXIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        Instance = this;

        audioSourceAlam = GetComponent<AudioSource>();

        PlaySFXAlam();
    }

    // Update is called once per frame
    void Update()
    {
        //PlaySFXAlam();
    }

    void PlaySFXAlam()
    {
        // Pagi (05:00 - 12.59)
        float minPagi = (5 * 60); float maxPagi = (12 * 60) + 59;

        // Sore (13:00 - 17.59)
        float minSore = (13 * 60); float maxSore = (17 * 60) + 59;

        float jamSekarang = DateTime.Now.Hour;
        float menitSekarang = DateTime.Now.Minute;
        float waktuSekarang = (jamSekarang * 60) + menitSekarang;

        if (waktuSekarang >= minPagi && waktuSekarang <= maxPagi) // Pagi
        {
            audioSourceAlam.clip = soundAlam[0];
            audioSourceAlam.loop = true;
            audioSourceAlam.Play();
        }
        else if (waktuSekarang >= minSore && waktuSekarang <= maxSore) // Sore
        {
            audioSourceAlam.clip = soundAlam[1];
            audioSourceAlam.loop = true;
            audioSourceAlam.Play();
        }
        else // Malam
        {
            audioSourceAlam.clip = soundAlam[2];
            audioSourceAlam.loop = true;
            audioSourceAlam.Play();
        }
    }

}
