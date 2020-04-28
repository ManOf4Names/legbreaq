// ===============================
// AUTHOR     : Corey Dotson
// CREATE DATE     : 3/23/20
// PURPOSE     : AI for an enemy that chases the player
// SPECIAL NOTES: Player tracking uses direction vector, therefore the speed scales down as the enemy approaches the player
// ===============================
// Change History: 
//
//==================================

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChasePlayer : MonoBehaviour
{
    public Transform player;
    public float moveSpeed = 1f;
    private Rigidbody2D rb;
    private Vector2 movement;

    public GameObject playerImpactEffect;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = player.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        //rb.rotation = angle;
        if (direction.magnitude < 40)
        {
            direction = direction / 2 * 3;
        } else if(direction.magnitude < 30) {
            direction = direction * 3;
        }
        else if (direction.magnitude < 20)
        {
            direction = direction * 5;
        }
        Debug.Log(direction.magnitude);
        movement = direction;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Instantiate(playerImpactEffect, transform.position, transform.rotation);
            //one health per hit
            PlayerHealthController.instance.DamagePlayer();
        }

    }


    private void FixedUpdate()
    {
        moveCharacter(movement);
    }

    void moveCharacter(Vector2 direction)
    {
        rb.MovePosition((Vector2)transform.position + (direction * moveSpeed * Time.deltaTime));
    }


}
