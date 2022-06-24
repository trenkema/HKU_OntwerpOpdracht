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

    public void Setup(CameraShaker _cameraShaker, Score _score, SpawnCoins _spawnCoins)
    {
        cameraShake = _cameraShaker;
        scoreScript = _score;
        spawnCoins = _spawnCoins;

        if (Color == 0)
            assignPoints = spawnCoins.ColorPoints[0];
        if (Color == 1)
            assignPoints = spawnCoins.ColorPoints[1];
        if (Color == 2)
            assignPoints = spawnCoins.ColorPoints[2];
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        cameraShake.shouldShake = true;
        explosionsAll = Instantiate(explosions, gameObject.transform.position, Quaternion.identity);
        explosions.Play();
        Destroy(gameObject);
        EventSystemNew<int>.RaiseEvent(Event_Type.ADD_SCORE, assignPoints);
    }
}
