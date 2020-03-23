using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargePlayer : MonoBehaviour
{
    public Transform player;
    public float chargeSpeed = 6f;
    private Rigidbody2D rb;
    private Vector2 movement;
    float timer;
    public float waitingTime = 2;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = player.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        //rb.rotation = angle;
        movement = direction;
    }

    private void FixedUpdate()
    {
        timer += Time.deltaTime;
        if (timer > waitingTime)
        {
            moveCharacter(movement);
            if (timer > waitingTime + 0.2)
            {
                timer = 0;
            }
        }
    }

    void moveCharacter(Vector2 direction)
    {
        rb.MovePosition((Vector2)transform.position + (direction * chargeSpeed * Time.deltaTime));
    }


}
