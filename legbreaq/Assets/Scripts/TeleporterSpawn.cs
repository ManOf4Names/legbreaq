using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleporterSpawn : MonoBehaviour
{
    public GameObject teleporter;
    public Transform teleporterSpawn;
    public bool picked;
    private bool doOnce = true;

    // Update is called once per frame
    void Update()
    {
        if (picked)
        {
            if (doOnce)
            {
                Instantiate(teleporter, teleporterSpawn.position, teleporterSpawn.rotation);
                Destroy(this);
                doOnce = false;
            }
        }
    }
}
