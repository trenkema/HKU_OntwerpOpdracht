using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SpawnCoins : MonoBehaviour
{
    // Array of the coins to spawn
    public GameObject[] coins;
    public GameObject newCoinParent;
    [Header("R-G-B / 0-1-2")]
    public int[] ColorPoints;
    public TextMeshProUGUI[] colorBoxes;
    public int coinsSize = 20;

    // Amount of coins spawned
    private int amountCoinsSpawned = 0;
    public int maxCoinsSpawned;

    // The range of X position
    [Header("X Spawn Range")]
    public float xMin;
    public float xMax;

    // The range of Y position
    [Header("Y Spawn Range")]
    public float yMin;
    public float yMax;

    public float minDistance;

    void Start()
    {
        colorBoxes[0].text = ColorPoints[0].ToString();
        colorBoxes[1].text = ColorPoints[1].ToString();
        colorBoxes[2].text = ColorPoints[2].ToString();

        for (int i = 0; i < maxCoinsSpawned; i++)
            spawnCoins();
    }

    void Update()
    {
        if (amountCoinsSpawned < maxCoinsSpawned)
        {
            spawnCoins();
        }
    }

    public void spawnCoins()
    {
        // Defines the min and max ranges for the x and y position
        Vector2 pos = new Vector2(Random.Range(xMin, xMax), Random.Range(yMin, yMax));
        pos = newCoinParent.transform.TransformPoint(pos);

        // Choose a new coin to spawn from the array
        GameObject coinsPrefab = coins[Random.Range(0, coins.Length)];

        // Creates the random coin at the random 2D position
        //Instantiate(coinsPrefab, pos, transform.rotation, GameObject.FindGameObjectWithTag("Canvas").transform);
        var checkResult = Physics2D.OverlapCircleAll(pos, minDistance);
        if (checkResult.Length == 0)
        {
            amountCoinsSpawned++;
            GameObject coin = Instantiate(coinsPrefab, pos, Quaternion.identity) as GameObject;
            coin.transform.SetParent(newCoinParent.transform, true);
            coin.transform.localScale = new Vector3(coinsSize, coinsSize, 0);
        }
        else
            return;
    }
}