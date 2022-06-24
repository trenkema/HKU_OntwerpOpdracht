using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ScreenWrap : MonoBehaviour
{
    [SerializeField] Canvas canvas;

    [SerializeField] private float screenOffsetX;
    [SerializeField] private float screenOffsetY;

    private float screenWidth;
    private float screenHeight;

    private void Start()
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            screenWidth = canvas.pixelRect.width / 4;
            screenHeight = canvas.pixelRect.height / 4;
        }
        else if (Application.platform == RuntimePlatform.WebGLPlayer || Application.platform == RuntimePlatform.WindowsEditor)
        {
            screenWidth = canvas.pixelRect.width / 2;
            screenHeight = canvas.pixelRect.height / 2;
        }

        screenWidth -= screenOffsetX;
        screenHeight -= screenOffsetY;
    }

    private void Update()
    {
        CheckOutOfBounds();
    }

    private void CheckOutOfBounds()
    {
        Vector2 playerPos = transform.localPosition;

        if (transform.localPosition.x > screenWidth)
        {
            playerPos.x = -screenWidth;
        }

        if (transform.localPosition.x < -screenWidth)
        {
            playerPos.x = screenWidth;
        }

        if (transform.localPosition.y > screenHeight)
        {
            playerPos.y = -screenHeight;
        }

        if (transform.localPosition.y < -screenHeight)
        {
            playerPos.y = screenHeight;
        }

        transform.localPosition = playerPos;
    }
}
