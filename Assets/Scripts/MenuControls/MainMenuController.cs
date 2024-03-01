using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public CanvasGroup OptionPanel;

    public void PlayGame()
    {
        SceneManager.LoadScene("LevelsMenu");
    }

    
    public void DrawingMenu()
    {
       SceneManager.LoadScene("DrawingMenu");
    }

    public void OptionsMenu()
    {
       SceneManager.LoadScene("OptionsMenu");
    }

    public void CreditsMenu()
    {
        SceneManager.LoadScene("CreditsMenu");
    }
    public void Back()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit!");
    }
}