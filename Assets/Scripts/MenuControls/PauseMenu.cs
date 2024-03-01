using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;
    [SerializeField] GameObject pauseButton;
    //[SerializeField] GameObject systemDisable;
    public void Pause()
    {
        pauseMenu.SetActive(true);
        pauseButton.SetActive(false);
        //systemDisable.SetActive(false);
        
        Time.timeScale = 0f;
    }
    public void Home()
    {
            SceneManager.LoadScene("MainMenu");
            Time.timeScale = 1f;
    }
    public void Resume()
    {
        pauseMenu.SetActive(false);
        pauseButton.SetActive(true);
        //systemDisable.SetActive(true);
        Time.timeScale = 1f;
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
    }
    public void Options()
    {
        SceneManager.LoadScene("OptionsMenu");
        Time.timeScale = 0f;
    }
    public void LevelSelect()
    {
        SceneManager.LoadScene("LevelsMenu");
        Time.timeScale = 1f;
    }
}
