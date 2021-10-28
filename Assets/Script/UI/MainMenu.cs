using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    //public Animator transition;
    public float transitiontime = 0f;

    public Animator animator;

    public TextMeshProUGUI HallOfFame;
    public TextMeshProUGUI Lastscore;
    public TextMeshProUGUI tips;
    private float highscore;
    private float lastscore;
    public static ScoreManager instance;
    private List<string> mylist = new List<string>(new string[] { "tips: You can pause the game with the pause button or the escape key", "tips: Enemies can have different number of life ", "tips: You can activate a cheat in the option menu" });


    private void Awake()
    {
        if (PlayerPrefs.HasKey("HighScore"))
        {
            highscore = PlayerPrefs.GetFloat("HighScore");
        }
        if (PlayerPrefs.HasKey("Last"))
        {
            lastscore = PlayerPrefs.GetFloat("Last");
        }

        Lastscore.text = "Last score: " + lastscore.ToString();
        HallOfFame.text = "Best score: " + highscore.ToString();
        
        tips.text = mylist[Random.Range(0,mylist.Count)];


    }

    public void PlayGame()
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }

    public void OptionGame()
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 2));
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    private IEnumerator LoadLevel(int levelIndex)
    {
        //transition.SetTrigger("start");
        animator.SetTrigger("start");

        yield return new WaitForSeconds(transitiontime);
        SceneManager.LoadScene(levelIndex);
    }

}