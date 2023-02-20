using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class InteractableObject : MonoBehaviour, Interactable
{
    public static InteractableObject Instance;

    public UnityEvent onInteract;
    public Sprite interaksiIcon;
    public Vector2 iconSize;
    public int ID;
    public string key;
    //public string interaksiTeks;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        ID = Random.Range(0, 999999);
    }

    public void Interact()
    {
        
    }
}
