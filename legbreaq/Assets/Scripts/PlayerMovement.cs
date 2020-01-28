using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Script for handling player movement (and animations) 
/// </summary>
public class PlayerMovement : MonoBehaviour
{
    public float speed;
    private Vector2 direction;
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        TakeInput();
        Move();
    }

    private void Move()
    {
        //use delta time to avoid speed scaling with framerate
        transform.Translate(direction * speed * Time.deltaTime);

        if (direction.x != 0 || direction.y != 0)
        {
            SetAnimatorMovement(direction);

        }
        else
        {
            //Prioritize idle animation -> set walking priority to 0
            animator.SetLayerWeight(1, 0);
        }
    }
    
    //Maybe implement configurable settings later
    private void TakeInput()
    {
        direction = Vector2.zero; //0,0

        if (Input.GetKey(KeyCode.W))
        {
            direction += Vector2.up;
        }
        if (Input.GetKey(KeyCode.A))
        {
            direction += Vector2.left;
        }
        if (Input.GetKey(KeyCode.S))
        {
            direction += Vector2.down;
        }
        if (Input.GetKey(KeyCode.D))
        {
            direction += Vector2.right;
        }
    }

    private void SetAnimatorMovement(Vector2 distance)
    {
        //Prioritize walking(animaiton) if moving
        animator.SetLayerWeight(1, 1);

        animator.SetFloat("xDir", direction.x);
        animator.SetFloat("yDir", direction.y);

    }
}
