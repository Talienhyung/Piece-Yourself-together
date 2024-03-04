using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomGravity : MonoBehaviour
{
    public float downwardForce = 5f; // Adjust this value to control the downward speed


    void Start()
    {
    }

    void FixedUpdate()
    {
        // Apply constant downward force
        transform.position += Vector3.down * downwardForce * Time.deltaTime;
    }
}
