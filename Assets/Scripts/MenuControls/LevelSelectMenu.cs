using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelectMenu : MonoBehaviour
{
    //case specific
    public string levelName;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void OpenScene()
    {
        SceneManager.LoadScene(levelName);
    }
}
