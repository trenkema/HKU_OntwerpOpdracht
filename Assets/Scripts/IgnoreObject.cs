using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IgnoreObject : MonoBehaviour
{
    private GameObject ignoreObject;

    void Start()
    {
        ignoreObject = GameObject.FindWithTag("Player");

        if (ignoreObject)
        {
            Physics2D.IgnoreCollision(ignoreObject.GetComponent<Collider2D>(), gameObject.GetComponent<Collider2D>());
        }
    }

    void Update()
    {
        ignoreObject = GameObject.FindWithTag("Player");
    }
}
