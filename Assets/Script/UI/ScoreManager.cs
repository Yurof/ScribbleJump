using System;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI score;
    public TextMeshProUGUI scoreGameOver;
    public float ScoreMultiplier = 10;

    //public TextMeshProUGUI HallOfFame;
    private float scorevalue;

    public GameObject player;
    private float HallOfFamevalue;

    // Start is called before the first frame update
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
            Debug.Log("save highscore");
        }
        PlayerPrefs.SetFloat("Last", scorevalue);
    }

    // Update is called once per frame
    private void Update()
    {
        SetscoreText();
        SetHallOfFame();
    }
}