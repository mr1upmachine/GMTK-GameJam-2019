using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int health = 1;
    public int pointValue = 100;

    private ParticleSystem particle;
    private SpriteRenderer sprite;
    private PolygonCollider2D polyCol;
    private CircleCollider2D cirCol;
    private CapsuleCollider2D capCol;
    private BoxCollider2D boxCol;
    public bool dead = false;

    void Start()
    {
        particle = GetComponent<ParticleSystem>();
        sprite = GetComponent<SpriteRenderer>();
        polyCol = GetComponent<PolygonCollider2D>();
        cirCol = GetComponent<CircleCollider2D>();
        capCol = GetComponent<CapsuleCollider2D>();
        boxCol = GetComponent<BoxCollider2D>();
    }

    //projectiles call this function to damage a character
    public void TakeDamage(int damage)
    {
        health -= damage;

        if(health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        dead = true;
        if(gameObject.tag == "Player")
        {
            particle.Play();
            sprite.enabled = false;
            if(polyCol != null) polyCol.enabled = false;
            if(cirCol != null) cirCol.enabled = false;
            if(capCol != null) capCol.enabled = false;
            if(boxCol != null) boxCol.enabled = false;
            GameManager.instance.GameOver();
        }else{
            GameManager.instance.IncrementGameScore(pointValue);
            particle.Play();
            sprite.enabled = false;
            if(polyCol != null) polyCol.enabled = false;
            if(cirCol != null) cirCol.enabled = false;
            if(capCol != null) capCol.enabled = false;
            if(boxCol != null) boxCol.enabled = false;
            Destroy(gameObject, 2f);
        }
    }
}
