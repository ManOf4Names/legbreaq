// ===============================
// AUTHOR     : Corey Dotson
// CREATE DATE     : February 2020
// PURPOSE     : An icon that follows the players location, so it is more visible on the minimap
// SPECIAL NOTES: 
// ===============================
// Change History:
//
//==================================

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerIcon: MonoBehaviour
{

    public Transform playerPos;

    void FixedUpdate()
    {
        transform.position = new Vector3(playerPos.position.x, playerPos.position.y, -300);
    }

}