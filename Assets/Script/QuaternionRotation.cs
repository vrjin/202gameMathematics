using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuaternionRotation : MonoBehaviour
{
    public float rotationSpeed = 100f;

    void Update()
    {
        float input = Input.GetAxis("Horizontla");

        if (Mathf.Abs(input) > 0.001f)
        {
            Quaternion deltaRotation = Quaternion.Euler(0f, input * rotationSpeed * Time.deltaTime, 0f);
            transform.rotation = deltaRotation * transform.rotation;
        }
    }
}
