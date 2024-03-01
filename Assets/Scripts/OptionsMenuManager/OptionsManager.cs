using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OptionsManager : MonoBehaviour
{
    [SerializeField] GameObject audioToggleButton;
    [SerializeField] Sprite audioToggleDown;
    [SerializeField] Sprite audioToggleUp;
    [SerializeField] AudioController audioController;


    private void Start()
    {
        if (PlayerPrefs.GetInt("audioEnabled", 1) == 1)
        {
            audioToggleButton.GetComponent<Image>().sprite = audioToggleUp;
            PlayerPrefs.SetInt("audioEnabled", 1);
        }
        else 
        { 
            audioToggleButton.GetComponent<Image>().sprite = audioToggleDown;
            PlayerPrefs.SetInt("audioEnabled", 0);
        }
    }

    public void ToggleAudio()
    {
        if (PlayerPrefs.GetInt("audioEnabled", 1) == 1)
        {
            audioToggleButton.GetComponent<Image>().sprite = audioToggleDown;
            PlayerPrefs.SetInt("audioEnabled", 0);
        }
        else
        {
            audioToggleButton.GetComponent<Image>().sprite = audioToggleUp;
            PlayerPrefs.SetInt("audioEnabled", 1);
        }
        audioController.UpdateAudioSource();
    }

    public void OptionsSceneManager(int SceneNumber)
    {
        SceneManager.LoadScene(SceneNumber);
    }
}
