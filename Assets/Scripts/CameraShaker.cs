using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraShaker : MonoBehaviour
{
    public float power = 0.7f;
    public float duration = 1.0f;
    private Transform camera;
    public float slowDownAmount = 1.0f;
    public bool shouldShake = false;
    public GameObject UI;

    Vector3 startPosition;
    float initialDuration;

    void Start()
    {
        camera = Camera.main.transform;
        startPosition = camera.localPosition;
        initialDuration = duration;
    }

    void Update()
    {
        if(shouldShake)
        {
            if(duration > 0)
            {
                iTween.ShakePosition(UI,new Vector3(0,0,0), 1);
                camera.localPosition = startPosition + Random.insideUnitSphere * power;
                duration -= Time.deltaTime * slowDownAmount;
            }
            else
            {
                shouldShake = false;
                duration = initialDuration;
                camera.localPosition = startPosition;
            }
        }
    }
}
