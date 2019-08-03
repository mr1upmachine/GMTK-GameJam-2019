using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    public float speed = 20f;
    public int damage = 1;
    Rigidbody2D body;

    // Start is called before the first frame update
    void Start()
    {
        //move in a straight line
        body = GetComponent<Rigidbody2D>();
        body.velocity = transform.up * speed;
    }

    // When colliding with another rigidbody2d
    void OnTriggerEnter2D (Collider2D hitInfo)
    {
        //check if colliding option has health script and deal damage if it does
        Health health = hitInfo.GetComponent<Health>();
        if(health != null)
        {
            health.TakeDamage(damage);
        }

        Destroy(gameObject);
    }
}
