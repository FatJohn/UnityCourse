using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public Ball Ball;

    private Vector3 offset;

    // Use this for initialization
    private void Start()
    {
        offset = transform.position - Ball.transform.position;
    }

    // Update is called once per frame
    private void Update()
    {
        if (Ball.transform.position.z >= 1829f)
        {
            return;
        }

        transform.position = Ball.transform.position + offset;
    }
}
