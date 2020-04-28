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
    public GameObject[] enemies;
    public float startTimeBetweenShots;
    public float timeBetweenShots;

    private int i = 0;
    private Vector3 offset = new Vector3(100, 0, 0);
    private bool alternate = true;
    private bool called = false;

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
    }

    public void shoot()
    {
        if (timeBetweenShots <= 0)
        {
            Instantiate(projectile, source.position, source.rotation);
            Instantiate(projectile, source.position + offset, source.rotation);
            Instantiate(projectile, source.position - offset, source.rotation);
            Instantiate(projectile, source.position + 2 * offset, source.rotation);
            Instantiate(projectile, source.position - 2 * offset, source.rotation);
            timeBetweenShots = startTimeBetweenShots;
        }
        else
        {
            timeBetweenShots -= Time.deltaTime;
        }
    }

    public void thirdStage()
    {
        if (timeBetweenShots <= 0)
            if (alternate)
            {
                {
                    for (int j = 0; j < 7; j++)
                    {
                        Instantiate(projectile, source.position, source.rotation);
                        Instantiate(projectile, source.position + offset, source.rotation);
                        Instantiate(projectile, source.position - offset, source.rotation);
                    }

                    timeBetweenShots = startTimeBetweenShots;
                }
            }
            else
            {
                Instantiate(projectile, source.position, source.rotation);
                Instantiate(projectile, source.position + offset, source.rotation);
                Instantiate(projectile, source.position - offset, source.rotation);
                Instantiate(projectile, source.position + 2 * offset, source.rotation);
                Instantiate(projectile, source.position - 2 * offset, source.rotation);
            }
        alternate = !alternate;
    }


    public void bigSpawn()
    {
        if (!called)
        {
            Instantiate(enemies[0], source.position, Quaternion.identity);
            Instantiate(enemies[3], source.position + offset, Quaternion.identity);
            Instantiate(enemies[2], source.position - offset, Quaternion.identity);
            Instantiate(enemies[1], source.position + 2 * offset, Quaternion.identity);
            Instantiate(enemies[0], source.position - 2 * offset, Quaternion.identity);
        }
        called = true;
    }

    public void laser()
    {
        if (timeBetweenShots <= 0)
        {
            Instantiate(projectile, source.position, source.rotation);
            Instantiate(projectile, source.position + offset, source.rotation);
            Instantiate(projectile, source.position - offset, source.rotation);
            timeBetweenShots = startTimeBetweenShots;
        }
        else
        {
            timeBetweenShots -= Time.deltaTime;
        }
    }

    public void spawnEnemies()
    {
        if (timeBetweenShots <= 0)
        {

            Instantiate(enemies[i], source.position, Quaternion.identity);
            Instantiate(enemies[i], source.position + offset, Quaternion.identity);
            Instantiate(enemies[i], source.position - offset, Quaternion.identity);
            Instantiate(enemies[i], source.position + 2 * offset, Quaternion.identity);
            Instantiate(enemies[i], source.position - 2 * offset, Quaternion.identity);
            timeBetweenShots = startTimeBetweenShots;
            i = (i + 1) % 4;
        }
        else
        {
            timeBetweenShots -= Time.deltaTime;
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
