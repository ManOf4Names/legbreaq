using UnityEngine;
using System.Collections;

public class PlayerProjectile : MonoBehaviour
{
    public int secondsToDestroy = 3;
    public float damage;

    public GameObject wallImpactEffect;
    public GameObject enemyImpactEffect;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        //TODO collide with wall ,   
        if (collision.tag != "Player" && (collision.tag == "Enemy" || collision.tag == "Boss"))
        {
            Instantiate(enemyImpactEffect, transform.position, transform.rotation);
            if (collision.GetComponent<EnemyRecieveDamage>() != null)
            {

                collision.GetComponent<EnemyRecieveDamage>().DealDamage(damage);
                //Debug.Log("Damage Dealt by PlayerProjectile");
            }
            //delete projectile 

            Destroy(gameObject);
        }

        if(collision.tag == "Wall")
        {
            Instantiate(wallImpactEffect, transform.position, transform.rotation);
            Destroy(gameObject);
        }

    }

    // TODO: fix bug doesn't seem to activate ever 
    private void OnBecameInvisible()
    {
        Debug.Log("Bullet Invis");
        Destroy(gameObject);
    }

    private void Awake()
    { 
        Destroy(gameObject, secondsToDestroy);
    }
}
