using UnityEngine;
using System.Collections;

public class EnemyRecieveDamage : MonoBehaviour
{
    public float health;
    public float maxHealth;
    //for future Damage animation
    //public GameObject bloodEffect;
    public Animator anim;
    private void Start()
    {
        //Damage animation
        //anim = GetComponent<Animator>();
        //anim.SetBool("isRunning", true);
        health = maxHealth;
    }

    public void DealDamage(float damage)
    {
        //Damage Animation
        //Instantiate(bloodEffect, transform.position, Quaternion.identity);
        //TODO: Play sound
        Debug.Log("dealt" + damage);
        health -= damage;
        CheckDeath();
    }

    private void CheckOverheal()
    {
        if (health > maxHealth)
        {
            health = maxHealth;
        }


    }

    private void CheckDeath()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }


}
