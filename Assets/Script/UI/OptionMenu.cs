using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OptionMenu : MonoBehaviour
{
    public Toggle toggle;

    private void Start()
    {
        if (PlayerPrefs.HasKey("Cheat"))
        {
            if (PlayerPrefs.GetInt("Cheat") == 1)
            {
                toggle.isOn = true;
            }
            else
            {
                toggle.isOn = false;
            }
        }
    }

    public void Menu()
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex - 2));
    }

    private IEnumerator LoadLevel(int levelIndex)
    {
        yield return new WaitForSeconds(0);
        SceneManager.LoadScene(levelIndex);
    }

    public void CheatToggle()
    {
        if (toggle.isOn == true)
        {
            PlayerPrefs.SetInt("Cheat", 1);
        }
        else
        {
            PlayerPrefs.SetInt("Cheat", 0);
        }
    }
}