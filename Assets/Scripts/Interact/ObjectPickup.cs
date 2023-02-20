using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPickup : MonoBehaviour, Interactable
{
    private float rotateSpeed = 50f;
    [SerializeField] private Vector3 _rotation;
    //private bool isPickedUp = false;
    private Rigidbody objectRigidbody;
    private Transform destinasi;
    private string sumbu;
    public bool rotatingKanan = false;
    public bool rotatingKiri = false;

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

    public void RotateObject(string y)
    {
        this.sumbu = y;
        //isRotating = true;
        _rotation = Vector3.up;
    }
    
    public void StopRotateObject()
    {
        //isRotating = false;
        _rotation = Vector3.zero;
    }

    private void FixedUpdate()
    {

        if (destinasi != null)
        {
            if (Input.GetKey(KeyCode.LeftArrow) || rotatingKiri == true)
            {
                _rotation = Vector3.up;
            }
            else if (Input.GetKey(KeyCode.RightArrow) || rotatingKanan == true)
            {
                _rotation = Vector3.down;
            }
            else
            {
                _rotation = Vector3.zero;
                //isRotating = false;
            }

            float lerpSpeed = 10f;
            Vector3 newPosition = Vector3.Lerp(transform.position, destinasi.position, Time.deltaTime * lerpSpeed);
            Interact();
            objectRigidbody.MovePosition(newPosition);
        }

    }

    public void RotateKanan()
    {
        _rotation = Vector3.down;
        Interact();
    }

    public void RotateKiri()
    {
        _rotation = Vector3.up;
        Interact();
    }

    public void Interact()
    {
        transform.Rotate(_rotation * rotateSpeed * Time.fixedDeltaTime);
    }
}
