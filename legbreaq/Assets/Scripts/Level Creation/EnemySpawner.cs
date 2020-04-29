// ===============================
// AUTHOR     : Corey Dotson
// CREATE DATE     : 3/25/20
// PURPOSE     : Spawns enemies
// SPECIAL NOTES: Needs a well-positioned box-collider to work
// ===============================
// Change History:
//
//==================================

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    private bool spawned;
    private bool isInRoom;
    public GameObject[] enemies;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isInRoom)
        {
            if (!spawned)
            {
                int seed = Random.Range(0, enemies.Length);
                Instantiate(enemies[seed], transform.position, Quaternion.identity);
                spawned = true;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isInRoom = true;
        }
    }

}
