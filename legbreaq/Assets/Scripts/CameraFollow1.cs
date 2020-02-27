using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CameraFollow1 : MonoBehaviour
{

    public Transform playerPos;
    int xShift;
    int yShift;

    void FixedUpdate()
    {
        
        if (playerPos.position.x > 0 && playerPos.position.x % 150 > 75 && playerPos.position.y > 0 && playerPos.position.y % 150 > 75)
        {
            xShift = 150 * ((int)playerPos.position.x / 150) + 150;
            yShift = 150 * ((int)playerPos.position.y / 150) + 150;
        }
        else if (playerPos.position.x < 0 && Math.Abs(playerPos.position.x) % 150 > 75 && playerPos.position.y < 0 && Math.Abs(playerPos.position.y) % 150 > 75)
        {
            xShift = 150 * ((int)playerPos.position.x / 150) - 150;
            yShift = 150 * ((int)playerPos.position.y / 150) - 150;
        }
        else if (playerPos.position.x > 0 && playerPos.position.x % 150 > 75)
        {
            xShift = 150 * ((int)playerPos.position.x / 150) + 150;
            yShift = 150 * ((int)playerPos.position.y / 150);
        }
        else if (playerPos.position.x < 0 && Math.Abs(playerPos.position.x) % 150 > 75)
        {
            xShift = 150 * ((int)playerPos.position.x / 150) - 150;
            yShift = 150 * ((int)playerPos.position.y / 150);
        }
        else if (playerPos.position.y > 0 && playerPos.position.y % 150 > 75)
        {
            xShift = 150 * ((int)playerPos.position.x / 150);
            yShift = 150 * ((int)playerPos.position.y / 150) + 150;
        } 
        else if (playerPos.position.y < 0 && Math.Abs(playerPos.position.y) % 150 > 75)
        {
            xShift = 150 * ((int)playerPos.position.x / 150);
            yShift = 150 * ((int)playerPos.position.y / 150) - 150;
        }
        else
        {
            xShift = 150 * ((int)playerPos.position.x / 150);
            yShift = 150 * ((int)playerPos.position.y / 150);
        }

        Debug.Log("Player X = " + playerPos.position.x + " Camera X = " + xShift);
        Debug.Log("Player Y = " + playerPos.position.y + " Camera Y = " + yShift);

        transform.position = new Vector3(xShift, yShift, transform.position.z);
    }

}
