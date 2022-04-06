using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Characters : MonoBehaviour
{
    public GameObject[] Character;

    void Start()
    {
        for (int i = 0; i < Character.Length; i++)
            Character[i].SetActive(false);

        Character[PlayerPrefs.GetInt("CharacterActive")].SetActive(true);
    }

    void Update()
    {
        //Character[PlayerPrefs.GetInt("CharacterActive")].SetActive(true);
    }
}
