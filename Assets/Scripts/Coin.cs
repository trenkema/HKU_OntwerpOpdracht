using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    Score scoreScript;
    SpawnCoins spawnCoins;
    [Header("R-G-B / 0-1-2")]
    public int Color;
    private int assignPoints;
    public ParticleSystem explosions;
    ParticleSystem explosionsAll;
    CameraShaker cameraShake;

    // Start is called before the first frame update
    void Start()
    {
        cameraShake = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraShaker>();
        scoreScript = GameObject.FindGameObjectWithTag("EventSystem").GetComponent<Score>();
        spawnCoins = GameObject.FindGameObjectWithTag("EventSystem").GetComponent<SpawnCoins>();

        if (Color == 0)
            assignPoints = spawnCoins.ColorPoints[0];
        if (Color == 1)
            assignPoints = spawnCoins.ColorPoints[1];
        if (Color == 2)
            assignPoints = spawnCoins.ColorPoints[2];
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        print("Collision Hit");
        cameraShake.shouldShake = true;
        explosionsAll = Instantiate(explosions, gameObject.transform.position, Quaternion.identity);
        explosions.Play();
        Destroy(gameObject);
        scoreScript.currentScore += assignPoints;
    }
}
