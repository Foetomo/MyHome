using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleFullscreen : MonoBehaviour
{
    string keyFullscreen = "Fullscreen";
    Toggle myToggle;

    private void Awake()
    {
        myToggle = this.GetComponent<Toggle>();
        int savedToggleValue = PlayerPrefs.GetInt(keyFullscreen);
        bool isToggleOn = savedToggleValue == 1 ? true : false;
        myToggle.isOn = isToggleOn;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        int toggleValue = myToggle.isOn ? 1 : 0;
        PlayerPrefs.SetInt(keyFullscreen, toggleValue);
    }
}
