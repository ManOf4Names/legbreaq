// ===============================
// AUTHOR     : Corey Dotson
// CREATE DATE     : 3/23/20
// PURPOSE     : Projectile that goes to players last location
// SPECIAL NOTES: projectile is destroyed when it reaches its destination, make it not do that
// ===============================
// Change History:
//
//==================================

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    public float speed;

    private Transform player;
    private Vector2 target;

    // Start is called before the first frame update
    public GameObject wallImpactEffect;
    public GameObject playerImpactEffect;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        target = new Vector2(player.position.x, player.position.y);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);

        if (transform.position.x == target.x && transform.position.y == target.y)
        {
            DestroyProjectile();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Instantiate(playerImpactEffect, transform.position, transform.rotation);
            //one health per hit
            PlayerHealthController.instance.DamagePlayer();
            DestroyProjectile();
        }
            
        if(other.CompareTag("Wall"))
        {
            Instantiate(wallImpactEffect, transform.position, transform.rotation);
            DestroyProjectile();
        }

    }

    void DestroyProjectile()
    {
        Destroy(gameObject);
    }
}
