using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fuel : MonoBehaviour
{
    [Header("Info")]
    private float maxFuel;
    private float fuel;
    private float calc_fuel;

    [Header("Settings")]
    public float burnRate = 1f;
    public Image fuelMeter;

    private GameObject player;
    public GameObject GameOverPanel;

    CameraShaker cameraShake;

    // Start is called before the first frame update
    void Start()
    {
        cameraShake = GameObject.
            FindGameObjectWithTag("MainCamera").
            GetComponent<CameraShaker>();

        player = GameObject.FindWithTag("Player");

        if (!PlayerPrefs.HasKey("Fuel"))
        {
            PlayerPrefs.SetFloat("Fuel", 15f);
            maxFuel = PlayerPrefs.GetFloat("Fuel");
        }
        else
            maxFuel = PlayerPrefs.GetFloat("Fuel");

        fuel = maxFuel;
        calc_fuel = fuel / maxFuel;
        fuelMeter.fillAmount = calc_fuel;
    }

    void Update()
    {
        fuel -= burnRate * Time.deltaTime;
        calc_fuel = fuel / maxFuel;
        fuelMeter.fillAmount = calc_fuel;

        if (fuel <= 0f)
        {
            cameraShake.shouldShake = false;
            fuel = 0;
            // Game Over and Destroy
            Destroy(player);
            Time.timeScale = 0;
            GameOverPanel.SetActive(true);
        }
    }
}
