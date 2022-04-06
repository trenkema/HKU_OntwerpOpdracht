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

    void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        float rotateAngle = 0;
        rotateAngle = joystick.Horizontal() * rotateSpeed * -1;

        playerRB.angularVelocity = rotateAngle;
        playerRB.velocity = transform.up * speed;
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if(coll.gameObject.tag == "Edge")
        {
            gameObject.transform.position = new Vector3(Random.Range(-2.75f, 2.75f), Random.Range(-2f, 2f), 0.0f);
        }
    }
}
