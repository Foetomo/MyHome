using System;
using UnityEngine;

public class SunLightController : MonoBehaviour
{
    private Light sunLight;
    //private float rotationPerMinute = 360f / 1440f;


    // Start is called before the first frame update
    void Start()
    {
        sunLight = GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        /* DateTime now = DateTime.Now;
         float angle = now.Hour * 30f + now.Minute * rotationPerMinute;
         sunLight.transform.rotation = Quaternion.Euler(new Vector3(angle, 0f, 0f));*/
        WaktuMatahari();
    }

    void WaktuMatahari()
    {
        // Subuh (03:00 - 04.59)
        float minSubuh = (3 * 60); float maxSubuh = (4 * 60) + 59;

        // Pagi (05:00 - 08.59)
        float minPagi = (5 * 60); float maxPagi = (8 * 60) + 59;

        // PagiKeSiang (09:00 - 11.59)
        float minPagiSiang = (9 * 60); float maxPagiSiang = (11 * 60) + 59;

        // Siang (12:00 - 14.59)
        float minSiang = (12 * 60); float maxSiang = (14 * 60) + 59;

        // Sore (15:00 - 17.59)
        float minSore = (12 * 60); float maxSore = (17 * 60) + 59;

        // Selain diatas berarti Malam (18:00 - 02:59)

        // Get Waktu Saat Ini (Lokal)
        float jamSekarang = DateTime.Now.Hour;
        float menitSekarang = DateTime.Now.Minute;
        float waktuSekarang = (jamSekarang * 60) + menitSekarang; // dalam menit

        // Cek Waktu Matahari
        if (waktuSekarang >= minSubuh && waktuSekarang <= maxSubuh) // Subuh
        {
            sunLight.transform.rotation = Quaternion.Euler(new Vector3(190f, 0f, 0f));
        }
        else if (waktuSekarang >= minPagi && waktuSekarang <= maxPagi) // Pagi
        {
            sunLight.transform.rotation = Quaternion.Euler(new Vector3(150f, 0f, 0f));
        }
        else if (waktuSekarang >= minPagiSiang && waktuSekarang <= maxPagiSiang) // Pagi ke Siang
        {
            sunLight.transform.rotation = Quaternion.Euler(new Vector3(120f, 0f, 0f));
        }
        else if (waktuSekarang >= minSiang && waktuSekarang <= maxSiang) // Siang
        {
            sunLight.transform.rotation = Quaternion.Euler(new Vector3(90f, 0f, 0f));
        }
        else if (waktuSekarang >= minSore && waktuSekarang <= maxSore) // Sore
        {
            sunLight.transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, 0f));
        }
        else // Malam
        {
            sunLight.transform.rotation = Quaternion.Euler(new Vector3(-90f, 0f, 0f));
        }
    }
}
