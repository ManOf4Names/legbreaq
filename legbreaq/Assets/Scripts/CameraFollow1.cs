using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CameraFollow1 : MonoBehaviour
{

    public Transform playerPos;
    int xShift;
    int yShift;
    public int offset = 0;

    void FixedUpdate()
    {
        
        if (playerPos.position.x > 0 && playerPos.position.x % 200 > 100 && playerPos.position.y > 0 && playerPos.position.y % 200 > 100)
        {
            xShift = 200 * ((int)playerPos.position.x / 200) + 200;
            yShift = 200 * ((int)playerPos.position.y / 200) + 200;
        }
        else if (playerPos.position.x < 0 && Math.Abs(playerPos.position.x) % 200 > 100 && playerPos.position.y < 0 && Math.Abs(playerPos.position.y) % 200 > 100)
        {
            xShift = 200 * ((int)playerPos.position.x / 200) - 200;
            yShift = 200 * ((int)playerPos.position.y / 200) - 200;
        }
        else if (playerPos.position.x > 0 && playerPos.position.x % 200 > 100)
        {
            xShift = 200 * ((int)playerPos.position.x / 200) + 200;
            yShift = 200 * ((int)playerPos.position.y / 200);
        }
        else if (playerPos.position.x < 0 && Math.Abs(playerPos.position.x) % 200 > 100)
        {
            xShift = 200 * ((int)playerPos.position.x / 200) - 200;
            yShift = 200 * ((int)playerPos.position.y / 200);
        }
        else if (playerPos.position.y > 0 && playerPos.position.y % 200 > 100)
        {
            xShift = 200 * ((int)playerPos.position.x / 200);
            yShift = 200 * ((int)playerPos.position.y / 200) + 200;
        } 
        else if (playerPos.position.y < 0 && Math.Abs(playerPos.position.y) % 200 > 100)
        {
            xShift = 200 * ((int)playerPos.position.x / 200);
            yShift = 200 * ((int)playerPos.position.y / 200) - 200;
        }
        else
        {
            xShift = 200 * ((int)playerPos.position.x / 200);
            yShift = 200 * ((int)playerPos.position.y / 200);
        }

        //Debug.Log("Player X = " + playerPos.position.x + " Camera X = " + xShift);
        //6 cxDebug.Log("Player Y = " + playerPos.position.y + " Camera Y = " + yShift);

        transform.position = new Vector3(xShift + offset, yShift + offset, transform.position.z);
    }

}
