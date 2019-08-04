using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int health = 1;
    public int pointValue = 100;

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
        if(gameObject.tag == "Player")
        {
            GameManager.instance.GameOver();
        }else{
            GameManager.instance.IncrementGameScore(pointValue);
            Destroy(gameObject);
        }
    }
}
