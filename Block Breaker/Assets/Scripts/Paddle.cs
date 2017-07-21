using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    public bool isAutoPlay = false;
    public float minX;
    public float maxX;

    private Ball ball;

    // Use this for initialization
    void Start()
    {
        ball = FindObjectOfType<Ball>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isAutoPlay)
        {
            MoveWithMouse();
        }
        else
        {
            MoveAuto();
        }
    }

    private void MoveAuto()
    {
        // * 16 => 變成 game unit
        var ballPosition = ball.transform.position;

        var paddlePosition = transform.position;
        paddlePosition.x = Mathf.Clamp(ballPosition.x, minX, maxX);

        transform.position = paddlePosition;
    }

    private void MoveWithMouse()
    {
        // * 16 => 變成 game unit
        var mousePosInBloacks = Input.mousePosition.x / Screen.width * 16;

        var paddlePosition = transform.position;
        paddlePosition.x = Mathf.Clamp(mousePosInBloacks, minX, maxX);

        transform.position = paddlePosition;
    }
}
