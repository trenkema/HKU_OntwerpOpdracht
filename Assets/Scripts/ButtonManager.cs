using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    public GameObject[] Panel;

    CameraShaker cameraShake;

    public GameObject[] UnlockedLevel;
    public int[] UnlockedLevelIndex;

    // Start is called before the first frame update
    void Start()
    {

        for(int i = 0; i < UnlockedLevel.Length; i++)
        {
            Debug.Log(PlayerPrefs.GetInt("UnlockedLevel" + UnlockedLevel[i]));

            if (PlayerPrefs.GetInt("UnlockedLevel" + UnlockedLevelIndex[i]) == 1)
            {
                UnlockedLevel[i].SetActive(false);
            }
            else
                UnlockedLevel[i].SetActive(true);
        }

        cameraShake = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraShaker>();
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void LoadScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void OpenPanel(int panel)
    {
        Panel[panel].SetActive(true);
    }

    public void ClosePanel(int panel)
    {
        Panel[panel].SetActive(false);
    }

    public void OpenSettings(int panel)
    {
        Panel[panel].SetActive(true);
        Time.timeScale = 0;
    }

    public void OpenSettingsInGame(int panel)
    {
        cameraShake.shouldShake = false;
        Panel[panel].SetActive(true);
        Time.timeScale = 0;
    }

    public void CloseSettings(int panel)
    {
        Panel[panel].SetActive(false);
        Time.timeScale = 1;
    }
}
