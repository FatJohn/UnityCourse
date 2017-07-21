using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private Paddle paddle;
    private bool hasStarted = false;
    private Vector3 paddleToBallVector;
    private Rigidbody2D rigiBody;
    private AudioSource boingSound;

    // Use this for initialization
    void Start()
    {
        paddle = FindObjectOfType<Paddle>();
        paddleToBallVector = transform.position - paddle.transform.position;
        rigiBody = GetComponent<Rigidbody2D>();
        boingSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (hasStarted == false)
        {
            // lock the ball relative to the paddle
            transform.position = paddle.transform.position + paddleToBallVector;

            // wait for a mouse press to launch
            if (Input.GetMouseButtonDown(0))
            {
                hasStarted = true;

                rigiBody.velocity = new Vector2(2f, 10f);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!hasStarted)
        {
            return;
        }

        Vector2 tweak = new Vector2(Random.Range(0f, 0.2f), Random.Range(0f, 0.2f));

        boingSound.Play();

        rigiBody.velocity += tweak;
    }
}
