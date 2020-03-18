 using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class PlayerMeleeWeapon : MonoBehaviour
{
    //using guide from Blackthornprod
    public float damage;
    private float attackInterval;
    public float startAttackInterval;

    public Transform attackPos;
    public float attackRange;
    public LayerMask whatIsEnemies;
    //For animation 
    //public Animator playerAnim;



    //Attach this as compoment on sword

    private void Update()
    {
        if (attackInterval <= 0)
        {
            if (Input.GetKey(KeyCode.Mouse0))
            {

                Debug.Log("swing");
                //Animate Attack
                //playerAnim.SetTrigger("MeleeAttack");
                //Deal damage in a circle
                Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, whatIsEnemies);
                for(int i = 0; i < enemiesToDamage.Length; i++)
                {
                    
                    enemiesToDamage[i].GetComponent<EnemyRecieveDamage>().DealDamage(damage);
                }
            }
            attackInterval = startAttackInterval;
        }
        else
        {
            attackInterval -= Time.deltaTime;
        }
            
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);

    }

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
