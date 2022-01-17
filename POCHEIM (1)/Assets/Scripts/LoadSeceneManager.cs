using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSeceneManager : MonoBehaviour
{

    public void LoadScene(string sceneName)
    {
        
        SceneManager.LoadScene(sceneName);
        Time.timeScale = 0f;
    }


    public void QuitGame()
    {
        Application.Quit();
    }

}