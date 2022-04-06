using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public Rigidbody2D rb;
    public Rigidbody2D hook;

    private bool isPressed = false;

    public float releaseTime = .15f;
    public float maxDragDistance = 2f;

    void Update()
    {
        if (isPressed)
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            if (Vector3.Distance(mousePos, hook.position) > maxDragDistance)
            {
                rb.position = hook.position + (hook.position - mousePos).normalized * maxDragDistance;
            }
            else
                rb.position = mousePos;
        }
    }

    void OnMouseDown()
    {
        isPressed = true;
        rb.isKinematic = true;
    }

    void OnMouseUp()
    {
        isPressed = false;
        rb.isKinematic = false;

        StartCoroutine(Release());
    }

    IEnumerator Release()
    {
        yield return new WaitForSeconds(releaseTime);

        GetComponent<SpringJoint2D>().enabled = false;
        this.enabled = false;
    }
}
