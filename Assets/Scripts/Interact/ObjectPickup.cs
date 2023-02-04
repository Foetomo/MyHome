using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPickup : MonoBehaviour, Interactable
{
    private Rigidbody objectRigidbody;
    private Transform destinasi;

    private void Awake()
    {
        objectRigidbody = GetComponent<Rigidbody>();
        //objectPickup = GetComponent<ObjectPickup>();
    }

    public void Grab(Transform destinasi)
    {
        this.destinasi = destinasi;
        objectRigidbody.useGravity = false;
    }

    public void Drop()
    {
        this.destinasi = null;
        objectRigidbody.useGravity = true;
    }

    private void FixedUpdate()
    {
        if (destinasi != null)
        {
            float lerpSpeed = 10f;
            Vector3 newPosition = Vector3.Lerp(transform.position, destinasi.position, Time.deltaTime * lerpSpeed);
            objectRigidbody.MovePosition(newPosition);
        }
    }

    public void Interact()
    {
        //throw new NotImplementedException();
    }
}
