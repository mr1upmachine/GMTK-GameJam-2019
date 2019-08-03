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
        body = GetComponent<Rigidbody2D>();
        body.velocity = transform.up * speed;
    }

    // Update is called once per frame
    void OnTriggerEnter2D (Collider2D hitInfo)
    {
        Health health = hitInfo.GetComponent<Health>();
        if(health != null)
        {
            health.TakeDamage(damage);
        }
    }
}
