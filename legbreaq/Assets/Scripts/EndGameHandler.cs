using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGameHandler : MonoBehaviour
{

    public string victoryScene;

    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindGameObjectWithTag("Boss") == null)
        {
            foreach (GameObject go in GameObject.FindGameObjectsWithTag("Enemy"))
            {
                Destroy(go);
            }
        }

        if (GameObject.FindGameObjectWithTag("Boss") == null && GameObject.FindGameObjectWithTag("Projectile") == null)
        {
            SceneManager.LoadScene(victoryScene);
        }

    }
}
