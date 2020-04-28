// ===============================
// AUTHOR     : Corey Dotson
// CREATE DATE     : 4/27/20
// PURPOSE     : 
// SPECIAL NOTES: 
// ===============================
// Change History:
//
//==================================


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss: EnemyRecieveDamage
{
    public float projectileDamage;
    public Transform source;
    public Slider healthBar;
    public GameObject projectile;
    public float timeBetweenShots = 0.5f;

    private Vector3 offset = new Vector3(100, 0, 0);

    private void Start()
    {
        //Damage animation
        //anim = GetComponent<Animator>();
        //anim.SetBool("isRunning", true);
        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.value = health;
        if (timeBetweenShots > 0) {
            timeBetweenShots -= Time.deltaTime;
        }

        if (timeBetweenShots == 0)
        {
            timeBetweenShots = 1.5f;
        }

    }

    public void shoot()
    {
        if (timeBetweenShots <= 0)
        {
            GameObject bullet = Instantiate(projectile, source.position, source. rotation);
            GameObject bullet1 = Instantiate(projectile, source.position + offset, source.rotation);
            GameObject bullet2 = Instantiate(projectile, source.position - offset, source.rotation);
        }
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

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerHealthController>().DamagePlayer();
        }
    }


}
