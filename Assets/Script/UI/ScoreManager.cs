using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI score;
    //public TextMeshProUGUI HallOfFame;
    private float scorevalue;
    public GameObject player;
    private float HallOfFamevalue;

    // Start is called before the first frame update
    void Start()
    {
        SetscoreText();
        HallOfFamevalue = PlayerPrefs.GetFloat("HighScore");
    }
    void SetscoreText()
    {
        scorevalue = (float)Math.Max(scorevalue, Math.Round((player.transform.position.y - 1.4f) * 10));
        score.text = scorevalue.ToString();
    }

    void SetHallOfFame()
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
    void Update()
    {
        SetscoreText();
        SetHallOfFame();
    }
}
