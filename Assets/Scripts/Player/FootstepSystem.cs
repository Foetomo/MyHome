using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class FootstepSystem : MonoBehaviour
{
    public static FootstepSystem Instance;
    public Sound[] footstepSound;
    public GameObject footstepPlay;
    public AudioSource audioSourceFootstep;

    private CharacterController controller;
    private float accumulated_Distance;

    RaycastHit hit;
    public Transform rayStart;
    public float range;
    public LayerMask layermask;

    [HideInInspector]
    public float step_Distance;

    AudioManager am;

    private void Awake()
    {
        Instance = this;

        controller = GetComponent<CharacterController>();
    }

    private void Start()
    {
        footstepPlay.SetActive(false);
    }

    private void Update()
    {
        am = FindObjectOfType<AudioManager>();
        //audioSourceFootstep = am.sfxSource;

        Debug.DrawRay(rayStart.position, rayStart.transform.up * range * -1, Color.green);

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        {
            PlayFootstep();
        }

        if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.D))
        {
            StopFootstep();
        }

        if (!controller.isGrounded)
        {
            return;
        }

        if (controller.velocity.sqrMagnitude > 0)
        {
            accumulated_Distance += Time.deltaTime;

            if (accumulated_Distance > step_Distance)
            {
                PlayFootstep();
                accumulated_Distance = 0f;
            }
        }
        else
        {
            StopFootstep();
            accumulated_Distance = 0f;
        }

    }

    public void PlayFootstep()
    {
        AudioFootstep();
        footstepPlay.SetActive(true);
    }

    public void StopFootstep()
    {
        AudioFootstep();
        footstepPlay.SetActive(false);
    }   

    void AudioFootstep()
    {
        if (Physics.Raycast(rayStart.position, rayStart.transform.up * -1, out hit, range, layermask))
        {
            if (hit.collider.CompareTag("Tiles"))
            {
                FootstepSystem.Instance.PlayFootstepSound("Tiles");
            }

            if (hit.collider.CompareTag("Grass"))
            {
                FootstepSystem.Instance.PlayFootstepSound("Grass");
            }
        }
    }   

    void PlayFootstepSound(string nama)
    {
        Sound s = Array.Find(footstepSound, x => x.nama == nama);
        audioSourceFootstep.pitch = Random.Range(0.8f, 1f);
        audioSourceFootstep.clip = s.clip;
    }

}
