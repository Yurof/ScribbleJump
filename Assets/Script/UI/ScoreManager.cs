using System;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI score;
    public TextMeshProUGUI scoreGameOver;
    public float ScoreMultiplier = 10;

    private float scorevalue;

    public GameObject player;
    private float HallOfFamevalue;

    private void Start()
    {
        SetscoreText();
        HallOfFamevalue = PlayerPrefs.GetFloat("HighScore");
    }

    private void SetscoreText()
    {
        scorevalue = (float)Math.Max(scorevalue, Math.Round((player.transform.position.y - 1.4f) * ScoreMultiplier));
        score.text = scorevalue.ToString();
        scoreGameOver.text = "your score: " + scorevalue.ToString() + "\n" + "your best score: " + HallOfFamevalue;
    }

    private void SetHallOfFame()
    {
        if (scorevalue > HallOfFamevalue)
        {
            HallOfFamevalue = scorevalue;
            PlayerPrefs.SetFloat("HighScore", HallOfFamevalue);
        }
        PlayerPrefs.SetFloat("Last", scorevalue);
    }

    private void Update()
    {
        SetscoreText();
        SetHallOfFame();
    }
}