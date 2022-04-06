using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Instructions : MonoBehaviour
{
    public GameObject InstructionsPanel;

    void Start()
    {
        InstructionsPanel.SetActive(true);
        Time.timeScale = 0;
    }

    public void OnClickStart()
    {
        InstructionsPanel.SetActive(false);
        Time.timeScale = 1;
    }
}
