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