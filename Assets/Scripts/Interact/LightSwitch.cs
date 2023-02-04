using UnityEngine;
using TMPro;

public class LightSwitch : MonoBehaviour, Interactable
{
    public Light lampu;
    public bool isOn = true;

    // Start is called before the first frame update
    void Start()
    {
        UpdateLight();
    }

    void UpdateLight()
    {
        lampu.enabled = isOn;
    }
    public void Switch()
    {
        isOn = !isOn;
        UpdateLight();
    }

    public void Interact()
    {
        Switch();
    }
}
