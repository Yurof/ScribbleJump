using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    private bool GameIsPaused = false;
    public GameObject PauseMenuUI;

    public void ResumeOrPause()
    {
        if (GameIsPaused)
        {
            PauseMenuUI.SetActive(false);
            Time.timeScale = 1f;
            GameIsPaused = false;
            AudioListener.volume = 1f;
        }
        else
        {
            PauseMenuUI.SetActive(true);
            Time.timeScale = 0f;
            GameIsPaused = true;
            AudioListener.volume = 0f;
        }
    }

    public void MainMenu()
    {
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex - 1);
    }
}