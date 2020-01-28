using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public GameObject projectile;
    public float minDamage;
    public float maxDamage;
    public float projectileForce;

    private void Update()
    {

        if (Input.GetMouseButtonDown(1))
        {

            GameObject spell = Instantiate(projectile, transform.position, Quaternion.identity);

            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 direction = (mousePos - (Vector2)transform.position).normalized;

            spell.GetComponent<Rigidbody2D>().velocity = direction * projectileForce;
            //might have to change projectile
            spell.GetComponent<PlayerProjectile>().damage = Random.Range(minDamage, maxDamage);


        }
    }
}
     