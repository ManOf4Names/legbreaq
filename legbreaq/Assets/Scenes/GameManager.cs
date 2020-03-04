using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int Time;
    public bool playerDiedGameRestarted;

    private void Awake()
    {
        MakeSingleton();
    }
    private void MakeSingleton()
    {
        if(instance != null)
        {
            Destroy(gameObject);
        } else {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
}
