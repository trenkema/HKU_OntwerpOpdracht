using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{
    public float speed;
    public Rigidbody2D playerRB;

    public float rotateSpeed;

    public VirtualJoystick joystick;

    float rotateAngle = 0;

    void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        rotateAngle = joystick.Horizontal() * rotateSpeed * -1;

        playerRB.angularVelocity = rotateAngle;
        playerRB.velocity = transform.up * speed;
    }
}
