using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public GameObject projectile;
    public float minDamage;
    public float maxDamage;
    public float projectileForce;

    public Transform source;
    public float fireRateCounter;
    public float timeBetweenShots;


    //TODO: combine all update functions to one caller
    private void Update()
    {
        if (fireRateCounter > 0)
        {
            fireRateCounter -= Time.deltaTime;
        }

        if (Input.GetMouseButtonDown(0) || Input.GetMouseButton(0))
        {
            FireWeapon();
        
        }
        
      
    }

    private void FireWeapon()
    {
        if (fireRateCounter <= 0)
        {
            // GameObject bullet = Instantiate(projectile, transform.position, Quaternion.identity);
            //Make bullet come from the gun instead of the player - have gun rotate with mouse 
            GameObject bullet = Instantiate(projectile, source.position, source.rotation);
            fireRateCounter = timeBetweenShots;

            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 direction = (mousePos - (Vector2)transform.position).normalized;

            bullet.GetComponent<Rigidbody2D>().velocity = direction * projectileForce;
            //might have to change projectile
            bullet.GetComponent<PlayerProjectile>().damage = Random.Range(minDamage, maxDamage);

            //TODO: Call gunshot sound here
        }
    }

  

}
     