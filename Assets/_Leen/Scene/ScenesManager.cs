using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ScenesManager : MonoBehaviour
{
    void Start()
    {
        Time.timeScale = 1f;
        Debug.Log("Game started");
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene("Main menu");
        Time.timeScale = 1f;
        Debug.Log("Game Resumed");
    }

    public void GoToHowTo()
    {
        SceneManager.LoadScene("How to");
        Debug.Log("How to scene");
    }

    public void GoToCredits()
    {
        SceneManager.LoadScene("Credits");
        Debug.Log("Credits scene");
    }

    //

    public void GoToSettings()
    {
        SceneManager.LoadScene("Settings");
    }

    public void SettingsAdd()
    {
        SceneManager.LoadScene("Settings", LoadSceneMode.Additive);
    }

    public void SettingsRemove()
    {
        SceneManager.UnloadSceneAsync("Settings");
    }

    //

    public void GoToLevelNumber(int levelNumber)
    {
        SceneManager.LoadScene($"Level {levelNumber}");
        Time.timeScale = 1f; // resume game
        Debug.Log("level started");
    }

    public void GoToSceneName(string SceneName)
    {
        SceneManager.LoadScene(SceneName);
        Time.timeScale = 1f; // resume game
        Debug.Log("level started");
    }

    //

    public void QuitGame()
    {
        Debug.Log("Game Quit");
        Application.Quit();
    }

    //

    public void ButtonSfx()
    {
        AudioManager.instance.playSFX("Buttons");
    }

    public void PlayAgain(string SceneName)
    {
        Time.timeScale = 1f; // resume game
        SceneManager.LoadScene(SceneName);
        Debug.Log("level restarted");
    }
}
