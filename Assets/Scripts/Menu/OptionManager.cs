using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionManager : MonoBehaviour
{
    public GameObject panelKontrol, buttonSelectedKontrol;
    public GameObject panelSuara, buttonSelectedSuara;
    public GameObject panelGrafik, buttonSelectedGrafik;
    public GameObject panelBahasa, buttonSelectedBahasa;

    public void Kontrol()
    {
        if (panelKontrol == true)
        {
            panelKontrol.SetActive(true);
            panelSuara.SetActive(false);
            panelGrafik.SetActive(false);
            panelBahasa.SetActive(false);
            buttonSelectedKontrol.SetActive(true);
            buttonSelectedSuara.SetActive(false);
            buttonSelectedGrafik.SetActive(false);
            buttonSelectedBahasa.SetActive(false);
        }
    }

    public void Suara()
    {
        if (panelSuara == true)
        {
            panelGrafik.SetActive(false);
            panelBahasa.SetActive(false);
            panelKontrol.SetActive(false);
            panelSuara.SetActive(true);
            buttonSelectedKontrol.SetActive(false);
            buttonSelectedSuara.SetActive(true);
            buttonSelectedGrafik.SetActive(false);
            buttonSelectedBahasa.SetActive(false);
        }
    }

    public void Grafik()
    {
        if (panelGrafik == true)
        {
            panelBahasa.SetActive(false);
            panelKontrol.SetActive(false);
            panelSuara.SetActive(false);
            panelGrafik.SetActive(true);
            buttonSelectedKontrol.SetActive(false);
            buttonSelectedSuara.SetActive(false);
            buttonSelectedGrafik.SetActive(true);
            buttonSelectedBahasa.SetActive(false);
        }
    }

    public void Bahasa()
    {
        if (panelBahasa == true)
        {
            panelKontrol.SetActive(false);
            panelSuara.SetActive(false);
            panelGrafik.SetActive(false);
            panelBahasa.SetActive(true);
            buttonSelectedKontrol.SetActive(false);
            buttonSelectedSuara.SetActive(false);
            buttonSelectedGrafik.SetActive(false);
            buttonSelectedBahasa.SetActive(true);
        }
    }
}
