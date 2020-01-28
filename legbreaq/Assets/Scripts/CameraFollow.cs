using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Class to be added to the MainCamera as a component
/// </summary>
public class CameraFollow : MonoBehaviour
{
    //All these properties set in Unity under camera 
    public Transform player;
    public float smoothing;
    public Vector3 offset;

    private void FixedUpdate()
    {
        if (player != null)
        {
            //Experiment with smoothing (~0.5 is ok) 
            Vector3 newPosition = Vector3.Lerp(transform.position, player.transform.position + offset, smoothing);
            transform.position = newPosition;
        }
    }
}
