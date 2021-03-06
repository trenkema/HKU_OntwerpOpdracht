using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    [Header("Score")]
    public int currentScore = 0;
    public int maxScore = 0;
    public TextMeshProUGUI score;

    CameraShaker cameraShake;

    //private int highScore;
    //public TextMeshProUGUI highScoreText;
    public int level;
    private bool winner;

    [Header("Reward")]
    private int currentCoins;
    public int rewardCoins;
    public int minReward, maxReward;
    public TextMeshProUGUI rewardText;
    public int UnlockLevel;

    public GameObject WinnerPanel;

    private void OnEnable()
    {
        EventSystemNew<int>.Subscribe(Event_Type.ADD_SCORE, AddScore);
    }

    private void OnDisable()
    {
        EventSystemNew<int>.Unsubscribe(Event_Type.ADD_SCORE, AddScore);
    }

    // Start is called before the first frame update
    void Start()
    {
        cameraShake = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraShaker>();
        winner = false;
        score.text = currentScore + " / " + maxScore;

        currentCoins = PlayerPrefs.GetInt("Coins");

        rewardText.text = "+" + rewardCoins + " Coins";
    }

    private void AddScore(int _scoreToAdd)
    {
        currentScore += _scoreToAdd;

        if (currentScore <= 0)
        {
            currentScore = 0;
        }

        score.text = currentScore + " / " + maxScore;

        if (currentScore >= maxScore && !winner)
        {
            rewardCoins = Random.Range(minReward, maxReward);
            rewardText.text = "+" + rewardCoins + " Coins";
            currentCoins += rewardCoins;
            PlayerPrefs.SetInt("Coins", currentCoins);
            PlayerPrefs.SetInt("UnlockedLevel" + UnlockLevel, 1);

            WinnerScreen();
        }
    }

    void WinnerScreen()
    {
        cameraShake.shouldShake = false;
        winner = true;
        WinnerPanel.SetActive(true);
        Time.timeScale = 0;
    }
}
