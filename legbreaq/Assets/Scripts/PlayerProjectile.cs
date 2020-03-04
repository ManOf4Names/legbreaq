using UnityEngine;
using System.Collections;

public class PlayerProjectile : MonoBehaviour
{
    public int secondsToDestroy = 3;
    public float damage;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name != "Player")
        {
            if (collision.GetComponent<EnemyRecieveDamage>() != null)
            {
                collision.GetComponent<EnemyRecieveDamage>().DealDamage(damage);
                Debug.Log("Damage Delt by PlayerProjectile");
            }
            //delete projectile 

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
