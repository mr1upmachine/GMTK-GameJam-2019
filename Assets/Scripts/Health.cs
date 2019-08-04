using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int health = 1;
    public int pointValue = 100;

    private ParticleSystem particle;
    private SpriteRenderer sprite;
    public bool dead = false;

    void Start()
    {
        particle = GetComponent<ParticleSystem>();
        sprite = GetComponent<SpriteRenderer>();
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
            GameManager.instance.GameOver();
        }else{
            GameManager.instance.IncrementGameScore(pointValue);
            particle.Play();
            sprite.enabled = false;
            Destroy(gameObject, 2f);
        }
    }
}
