using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    private int Coins;
    public TextMeshProUGUI coinsBalance;
    public GameObject[] characters;
    public int[] price;
    public GameObject[] active;

    public Characters characterScript;

    void Start()
    {
        // Check The Amount Of Coins
        if (!PlayerPrefs.HasKey("Coins"))
        {
            PlayerPrefs.SetInt("Coins", 0);
            PlayerPrefs.GetInt("Coins");
        }
        else
            PlayerPrefs.GetInt("Coins");

        // Check Which Character Is Active
        if (!PlayerPrefs.HasKey("CharacterActive"))
        {
            PlayerPrefs.SetInt("CharacterActive", 0);
            PlayerPrefs.GetInt("CharacterActive");
        }
        else
            PlayerPrefs.GetInt("CharacterActive");

        // First disable all character actives
        for (int i = 0; i < characters.Length; i++)
        {
            characters[i].SetActive(false);

            if (!PlayerPrefs.HasKey("Bought" + i))
            {
                PlayerPrefs.SetString("Bought" + i, "false");
                PlayerPrefs.GetString("Bought" + i);
            }
            else
                PlayerPrefs.GetString("Bought" + i);

            if (PlayerPrefs.GetString("Bought" + i) == "true")
            {
                characters[i].SetActive(true);
            }
        }

        // Then Enable The True Active Character
        active[PlayerPrefs.GetInt("CharacterActive")].SetActive(true);

        // Asign The PlayerPref Coins To The Variable Coins
        Coins = PlayerPrefs.GetInt("Coins");
        // Asign The Coins Amount To The CoinsBalance Text
        coinsBalance.text = Coins + " Coins";
    }

    void Update()
    {
        Coins = PlayerPrefs.GetInt("Coins");
        coinsBalance.text = Coins + " Coins";

        if (Input.GetKeyDown(KeyCode.L))
        {
            PlayerPrefs.DeleteKey("CharacterActive");
            for (int i = 0; i < characters.Length; i++)
            {
                PlayerPrefs.DeleteKey("Bought" + i);
            }
        }
    }

    public void SetActive(int i)
    {
        Debug.Log(i);
        if (PlayerPrefs.GetString("Bought" + i) == "false")
        {
            if (Coins >= price[i])
            {
                PlayerPrefs.SetString("Bought" + i, "true");
                Coins -= price[i];
                PlayerPrefs.SetInt("Coins", Coins);
                PlayerPrefs.SetInt("CharacterActive", i);

                for (i = 0; i < characters.Length; i++)
                {
                    characterScript.Character[i].SetActive(false);
                    active[i].SetActive(false);
                }

                characters[PlayerPrefs.GetInt("CharacterActive")].SetActive(true);
                active[PlayerPrefs.GetInt("CharacterActive")].SetActive(true);
                characterScript.Character[PlayerPrefs.GetInt("CharacterActive")].SetActive(true);
            }
        }
        else
        {
            PlayerPrefs.SetInt("CharacterActive", i);

            for (i = 0; i < characters.Length; i++)
            {
                characterScript.Character[i].SetActive(false);
                active[i].SetActive(false);
            }

            active[PlayerPrefs.GetInt("CharacterActive")].SetActive(true);
            characterScript.Character[PlayerPrefs.GetInt("CharacterActive")].SetActive(true);
        }
    }
}
