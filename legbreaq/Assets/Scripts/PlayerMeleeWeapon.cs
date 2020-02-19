using UnityEngine;
using System.Collections;

public class PlayerMeleeWeapon : MonoBehaviour
{
    public float damage;
    //Attach this as compoment on sword
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name != "Player")
        {
            if (collision.GetComponent<EnemyRecieveDamage>() != null)
            {
                collision.GetComponent<EnemyRecieveDamage>().DealDamage(damage);
                Debug.Log("Damage Delt");
            }
        }
    }
}
