using System;
using UnityEngine;

public class Door : MonoBehaviour, Interactable
{
    public Animator animator;
    public string nama = "Open";

    public void ToogleBool(string boolname)
    {
        animator.SetBool(boolname, !animator.GetBool(boolname));
    }

    public void Interact()
    {
        if (!animator.GetBool("Open"))
        {
            AudioManager.Instance.PlaySFX("OpenDoor");
        }
        else
        {
            AudioManager.Instance.PlaySFX("CloseDoor");
        }
        animator.SetBool(nama, !animator.GetBool(nama));
    }

}