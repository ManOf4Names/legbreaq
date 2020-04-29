﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Teleporter : MonoBehaviour
{

    public string nextScene;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (GameObject.FindGameObjectWithTag("Enemy") == null)
        {
            if (other.CompareTag("Player"))
            {
                SceneManager.LoadScene(nextScene);
            }
        }
    }
}
