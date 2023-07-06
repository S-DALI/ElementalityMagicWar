using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity : MonoBehaviour
{
    private float gravity = -9.81f;
    private Vector3 velocityOject;

    public Vector3 Velocity()
    {
        velocityOject.y += gravity * Time.deltaTime;
        return velocityOject;
    }

    public Vector3 Jump(float jumpForce)
    {
        velocityOject.y = Mathf.Sqrt(jumpForce * -2f * gravity);
        return velocityOject;
    }
}
