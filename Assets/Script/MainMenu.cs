using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public GameObject settingsWindow;

    public void StartGame()
    {
        SceneManager.LoadScene("1");

    }

    public void CreditsButton()
    {
        SceneManager.LoadScene("Credits");

    }

    public void BackButton()
    {
        SceneManager.LoadScene("MainMenu");

    }

    public void SettingsButton()
    {
        settingsWindow.SetActive(true);
    }

    public void QuitSettingsButton()
    {
        settingsWindow.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
