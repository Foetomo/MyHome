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
        animator.SetBool(nama, !animator.GetBool(nama));
    }

}