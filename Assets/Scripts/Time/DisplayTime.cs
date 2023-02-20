using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DisplayTime : MonoBehaviour
{
    public TextMeshProUGUI display;
    public float jam;
    public float menit;
    public float detik;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        jam = System.DateTime.Now.Hour;
        menit = System.DateTime.Now.Minute;
        detik = System.DateTime.Now.Second;
        display.text = "" + jam + " : " + menit + " : " + detik;
    }
}
