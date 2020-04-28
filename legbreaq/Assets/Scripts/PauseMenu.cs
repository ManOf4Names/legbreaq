using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


//Using Brakeys video pause menu

public class PauseMenu : MonoBehaviour
{

    public string mainMenuScene;
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;


    private void Start()
    {
        Time.timeScale = 1f;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(GameIsPaused)
            {
                Resume();
            } else
            {
                Pause();
            }

        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0;
        GameIsPaused = true;
    }

    public void LoadMenu()
    {
        Debug.Log("Loading Menu");
     
        SceneManager.LoadScene(mainMenuScene);
    }

    public void QuitGame()
    {
        Debug.Log("quitting game");
        Application.Quit();
    }
}
