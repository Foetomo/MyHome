using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Window : MonoBehaviour, Interactable
{
    public Animator animatorWindow;
    public string nama = "Open";

    public void ToogleBool(string boolname)
    {
        animatorWindow.SetBool(boolname, !animatorWindow.GetBool(boolname));
    }

    public void Interact()
    {
        if (!animatorWindow.GetBool("Open"))
        {
            AudioManager.Instance.PlaySFX("OpenWindow");
        }
        else
        {
            AudioManager.Instance.PlaySFX("CloseWindow");
        }
        animatorWindow.SetBool(nama, !animatorWindow.GetBool(nama));
    }
}
