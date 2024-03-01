using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndLevel : MonoBehaviour

{
    [SerializeField] GameObject systemDisable;

    
  
    public void Disable()
    {
      systemDisable.SetActive(false);
    } 
     public void Home()
    {
            SceneManager.LoadScene("MainMenu");
           
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        
    }

        public void LevelSelect()
    {
        SceneManager.LoadScene("LevelsMenu");
        Time.timeScale = 1f;
    }

}
