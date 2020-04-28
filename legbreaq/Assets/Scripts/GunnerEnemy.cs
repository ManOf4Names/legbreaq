// ===============================
// AUTHOR     : Corey Dotson
// CREATE DATE     : 3/23/20
// PURPOSE     : AI for an enemy that shoots at the player
// SPECIAL NOTES: This AI needs its values tweaked a bit so it feels a bit more natural
// ===============================
// Change History:
//
//==================================

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunnerEnemy : MonoBehaviour
{
    public float moveSpeed;
    public float stopDistance;
    public float retreatDistance;
    private Rigidbody2D rb;
    private Vector2 movement;
    private float timeBtwShots;
    public float startTimeBtwShots;

    public GameObject projectile;
    public Transform player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = this.GetComponent<Rigidbody2D>();
        timeBtwShots = startTimeBtwShots;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 direction = player.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        movement = direction;
        if(Vector2.Distance(transform.position, player.position) > stopDistance)
        {
            moveCharacter(movement, 1);
        }
        else if (Vector2.Distance(transform.position, player.position) < retreatDistance)
        {
            moveCharacter(-movement, 3);
        }

        if (timeBtwShots <= 0)
        {
            Instantiate(projectile, transform.position, Quaternion.identity);
            timeBtwShots = startTimeBtwShots;
        }
        else
        {
            timeBtwShots -= Time.deltaTime;
        }


    }

    void moveCharacter(Vector2 direction, float speedScale)
    {
        rb.MovePosition((Vector2)transform.position + (direction * moveSpeed * speedScale * Time.deltaTime));
    }
}
