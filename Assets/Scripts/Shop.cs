using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    public Color inActiveColor;
    public Color activeColor;

    public TextMeshProUGUI coinsBalance;

    public Image[] buttonImages;

    public TextMeshProUGUI[] buttonTexts;

    public int[] price;

    public Characters characterScript;

    private int Coins;

    void Start()
    {
        // Check The Amount Of Coins
        if (!PlayerPrefs.HasKey("Coins"))
        {
            PlayerPrefs.SetInt("Coins", 0);
        }

        // Check Which Character Is Active
        if (!PlayerPrefs.HasKey("CharacterActive"))
        {
            PlayerPrefs.SetInt("CharacterActive", 0);
        }

        // First disable all character actives
        for (int i = 0; i < buttonImages.Length; i++)
        {
            buttonImages[i].color = inActiveColor;

            if (!PlayerPrefs.HasKey("Bought" + i))
            {
                if (i != 0)
                    PlayerPrefs.SetString("Bought" + i, "false");
                else
                    PlayerPrefs.SetString("Bought" + i, "true");
            }

            if (PlayerPrefs.GetString("Bought" + i) == "true")
            {
                buttonTexts[i].text = "Inactive";
            }
        }

        // Then Enable The True Active Character
        buttonImages[PlayerPrefs.GetInt("CharacterActive", 0)].color = activeColor;
        buttonTexts[PlayerPrefs.GetInt("CharacterActive", 0)].text = "Active";
        characterScript.Character[PlayerPrefs.GetInt("CharacterActive", 0)].SetActive(true);

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
            for (int i = 0; i < buttonImages.Length; i++)
            {
                PlayerPrefs.DeleteKey("Bought" + i);
            }
        }
    }

    public void SetActive(int i)
    {
        if (PlayerPrefs.GetString("Bought" + i) == "false")
        {
            if (Coins >= price[i])
            {
                PlayerPrefs.SetString("Bought" + i, "true");
                Coins -= price[i];
                PlayerPrefs.SetInt("Coins", Coins);
                PlayerPrefs.SetInt("CharacterActive", i);

                for (i = 0; i < buttonImages.Length; i++)
                {
                    characterScript.Character[i].SetActive(false);

                    buttonImages[i].color = inActiveColor;

                    if (PlayerPrefs.GetString("Bought" + i) == "true")
                    {
                        buttonTexts[i].text = "Inactive";
                    }
                }

                buttonImages[PlayerPrefs.GetInt("CharacterActive", 0)].color = activeColor;
                buttonTexts[PlayerPrefs.GetInt("CharacterActive", 0)].text = "Active";
                characterScript.Character[PlayerPrefs.GetInt("CharacterActive", 0)].SetActive(true);
            }
        }
        else
        {
            PlayerPrefs.SetInt("CharacterActive", i);

            for (i = 0; i < buttonImages.Length; i++)
            {
                characterScript.Character[i].SetActive(false);
                buttonImages[i].color = inActiveColor;

                if (PlayerPrefs.GetString("Bought" + i) == "true")
                {
                    buttonTexts[i].text = "Inactive";
                }
            }

            buttonImages[PlayerPrefs.GetInt("CharacterActive", 0)].color = activeColor;
            buttonTexts[PlayerPrefs.GetInt("CharacterActive", 0)].text = "Active";
            characterScript.Character[PlayerPrefs.GetInt("CharacterActive", 0)].SetActive(true);
        }
    }
}
