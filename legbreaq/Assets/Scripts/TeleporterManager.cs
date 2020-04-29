using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleporterManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }


    void Update()
    {
        GameObject[] teleporters = GameObject.FindGameObjectsWithTag("Teleporter");
        teleporters[Random.Range(0, teleporters.Length)].GetComponent<TeleporterSpawn>().picked = true;
    }
}
