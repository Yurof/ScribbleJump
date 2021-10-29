using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReplayMenu : MonoBehaviour
{
    //public Animator transition;
    public float transitiontime = 1f;

    public void PlayGame()
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex - 1));
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    private IEnumerator LoadLevel(int levelIndex)
    {
        //transition.SetTrigger("start");
        yield return new WaitForSeconds(transitiontime);
        SceneManager.LoadScene(levelIndex);
    }
}