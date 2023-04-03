using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DisplayTime : MonoBehaviour
{
    public TextMeshProUGUI display;
    private string jam;
    private string menit;
    private string detik;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        JamDigital();
    }

    void JamDigital()
    {
        DateTime waktuSekarang = DateTime.Now;
        jam = waktuSekarang.Hour.ToString().PadLeft(2, '0');
        menit = waktuSekarang.Minute.ToString().PadLeft(2, '0');
        detik = waktuSekarang.Second.ToString().PadLeft(2, '0');
        display.text = jam + " : " + menit;
    }
}
