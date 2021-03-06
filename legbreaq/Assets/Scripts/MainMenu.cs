﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenu : MonoBehaviour
{
    public string StartLevelScene;
    public void PlayGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(StartLevelScene);
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        Debug.Log("Quitting");
        Application.Quit();
    }
}
