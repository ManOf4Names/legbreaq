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
    public Transform weapon;

    public float dashSpeed = 800f;
    public float dashLength = 0.07f;
    public float dashCooldown = 1f;
    public float dashCdCounter;
    //Dash duration
    public float dashCounter;

    //Melee
    public Collider2D swordCol;
    public Transform swordSource;
    public float meleeDamage;

    void Start()
    {
        /*
        animator = GetComponent<Animator>();
        swordCol = GameObject.Find("SwordCollider").GetComponent<Collider2D>();*/
    }

    private void Update()
    {
        TakeInput();
        Move();
        //RotateWeapon();
        Dash();

    }


    /// <summary>
    /// Rotate the weapon with the mouse
    /// </summary>
    private void RotateWeapon()
    {
        //rotate gun arm
        Vector3 mousePos = Input.mousePosition;
        Vector3 screenPoint = Camera.main.WorldToScreenPoint(transform.localPosition);
        Vector2 offset = new Vector2(mousePos.x - screenPoint.x, mousePos.y - screenPoint.y);
        float angle = Mathf.Atan2(offset.y, offset.x) * Mathf.Rad2Deg;
        weapon.rotation = Quaternion.Euler(0, 0, angle);
    }

    private void Move()
    {
        //use delta time to avoid speed scaling with framerate
        transform.Translate(direction * speed * Time.deltaTime);
        /*
        if (direction.x != 0 || direction.y != 0)
        {
            SetAnimatorMovement(direction);

        }
        else
        {
            //Prioritize idle animation -> set walking priority to 0
            animator.SetLayerWeight(1, 0);
        }*/
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

        if (Input.GetKeyDown(KeyCode.F))
        {
            Melee();
        }


    }


    /*
    private void SetAnimatorMovement(Vector2 distance)
    {
        //Prioritize walking(animaiton) if moving
        animator.SetLayerWeight(1, 1);

        animator.SetFloat("xDir", direction.x);
        animator.SetFloat("yDir", direction.y);

    }*/

    public void Dash()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //if dash isnt happening, and the cool down timer ran out 
            if (dashCdCounter <= 0 && dashCounter <= 0)
            {
                speed += dashSpeed;
                dashCounter = dashLength;
                //TODO: add sound, damage, invincibility? 
            }
        }

        if (dashCounter > 0)
        {
            dashCounter -= Time.deltaTime;
            if (dashCounter <= 0)
            {
                //Remove effects, reset cooldown 
                speed -= dashSpeed;
                dashCdCounter = dashCooldown;
            }
        }

        if (dashCdCounter > 0)
        {
            dashCdCounter -= Time.deltaTime;
        }
    }

    public void Melee()
    {
        //Play animation 
        animator.SetTrigger("Melee");
        swordCol.enabled = true;
        Debug.Log("melee");
        Idle();
    }

    public void Idle()
    {
        swordCol.enabled = false;
        animator.ResetTrigger("Melee");
        Debug.Log("idle");
    }






}
