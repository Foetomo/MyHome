using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionManager : MonoBehaviour
{
    public GameObject panelKontrol, buttonSelectedKontrol;
    public GameObject panelSuara, buttonSelectedSuara;
    public GameObject panelGrafik, buttonSelectedGrafik;
    public GameObject panelBahasa, buttonSelectedBahasa;
    public static int indexOpsi;

    private void Awake()
    {
        indexOpsi = PlayerPrefs.GetInt("opsi", 0);
    }

    private void Update()
    {
        if (indexOpsi == 0)
        {
            Kontrol();
        }

        if (indexOpsi == 1)
        {
            Suara();
        }

        if (indexOpsi == 2)
        {
            Grafik();
        }

        if (indexOpsi == 3)
        {
            Bahasa();
        }
    }

    public void Kontrol()
    {
        if (panelKontrol == true)
        {
            indexOpsi = 0;
            panelKontrol.SetActive(true);
            panelSuara.SetActive(false);
            panelGrafik.SetActive(false);
            panelBahasa.SetActive(false);
            buttonSelectedKontrol.SetActive(true);
            buttonSelectedSuara.SetActive(false);
            buttonSelectedGrafik.SetActive(false);
            buttonSelectedBahasa.SetActive(false);
            PlayerPrefs.SetInt("opsi", indexOpsi);

        }
    }

    public void Suara()
    {
        if (panelSuara == true)
        {
            indexOpsi = 1;
            panelGrafik.SetActive(false);
            panelBahasa.SetActive(false);
            panelKontrol.SetActive(false);
            panelSuara.SetActive(true);
            buttonSelectedKontrol.SetActive(false);
            buttonSelectedSuara.SetActive(true);
            buttonSelectedGrafik.SetActive(false);
            buttonSelectedBahasa.SetActive(false);
            PlayerPrefs.SetInt("opsi", indexOpsi);
        }
    }

    public void Grafik()
    {
        if (panelGrafik == true)
        {
            indexOpsi = 2;
            panelBahasa.SetActive(false);
            panelKontrol.SetActive(false);
            panelSuara.SetActive(false);
            panelGrafik.SetActive(true);
            buttonSelectedKontrol.SetActive(false);
            buttonSelectedSuara.SetActive(false);
            buttonSelectedGrafik.SetActive(true);
            buttonSelectedBahasa.SetActive(false);
            PlayerPrefs.SetInt("opsi", indexOpsi);
        }
    }

    public void Bahasa()
    {
        if (panelBahasa == true)
        {
            indexOpsi = 3;
            panelKontrol.SetActive(false);
            panelSuara.SetActive(false);
            panelGrafik.SetActive(false);
            panelBahasa.SetActive(true);
            buttonSelectedKontrol.SetActive(false);
            buttonSelectedSuara.SetActive(false);
            buttonSelectedGrafik.SetActive(false);
            buttonSelectedBahasa.SetActive(true);
            PlayerPrefs.SetInt("opsi", indexOpsi);
        }
    }
}
