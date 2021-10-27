using System.Collections;
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
    private float highscore;
    private float lastscore;
    public static ScoreManager instance;

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