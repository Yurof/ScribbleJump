using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OptionMenu : MonoBehaviour
{
    public void Menu()
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex - 2));
    }

    private IEnumerator LoadLevel(int levelIndex)
    {
        //transition.SetTrigger("start");

        yield return new WaitForSeconds(0);
        SceneManager.LoadScene(levelIndex);
    }

    public void CheatToggle()
    {
        Debug.Log(PlayerPrefs.GetInt("Cheat"));
        if (true)
        {
            if (PlayerPrefs.GetInt("Cheat") == 0)
            {
                PlayerPrefs.SetInt("Cheat", 1);
            }
            else
            {
                PlayerPrefs.SetInt("Cheat", 0);
                
            }
        }
        Debug.Log(PlayerPrefs.GetInt("Cheat"));

    }
}