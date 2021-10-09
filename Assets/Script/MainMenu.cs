using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    //public Animator transition;
    public float transitiontime = 1f;
    public TextMeshProUGUI HallOfFame;
    public TextMeshProUGUI Lastscore;
    private float highscore;
    private float lastscore;
    public static ScoreManager instance;

    private void Awake()
    {
        if (PlayerPrefs.HasKey("HighScore"))
        {
            Debug.Log("load highscore");
            highscore = PlayerPrefs.GetFloat("HighScore");
        }
        if (PlayerPrefs.HasKey("Last"))
        {
            Debug.Log("load highscore");
            lastscore = PlayerPrefs.GetFloat("Last");
        }

        Lastscore.text = "Last score: "+lastscore.ToString();
        HallOfFame.text = "Best score: " + highscore.ToString();
    }
    public void PlayGame()
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    IEnumerator LoadLevel(int levelIndex)
    {
        //transition.SetTrigger("start");

        yield return new WaitForSeconds(transitiontime);
        SceneManager.LoadScene(levelIndex);
    }


    // Update is called once per frame

}
