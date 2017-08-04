using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public Vector3 LaunchSpeed;

    private Rigidbody rigiBody;
    private AudioSource audioSource;

    // Use this for initialization
    private void Start()
    {
        rigiBody = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();

        rigiBody.velocity = LaunchSpeed;

        audioSource.Play();
    }

    // Update is called once per frame
    private void Update()
    {
    }
}
