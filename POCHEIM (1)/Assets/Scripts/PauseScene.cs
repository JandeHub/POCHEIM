using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseScene : MonoBehaviour
{
    private static bool GameIsPaused;

    [SerializeField]
    private GameObject pauseMenuUI;
    void OnEnable()
    {
        GetComponent<InputSystemKeyboard>().OnPause += GamePaused;

    }

    void OnDisable()
    {
        GetComponent<InputSystemKeyboard>().OnPause -= GamePaused;

    }

    void Start()
    {
        GameIsPaused = false;
    }

    void GamePaused()
    {
        if(GameIsPaused)
        {
            ResumeGame();
        }
        else
        {
            PauseGame();
        }
    }

    public void ResumeGame()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;

        GameIsPaused = false;
    }

    public void PauseGame()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;

        GameIsPaused = true;
    }
}
