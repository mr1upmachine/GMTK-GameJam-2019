using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpriteSwap : MonoBehaviour
{
    private Health health;
    private SpriteRenderer spriteRend;
    private int currentHealth;

    public Sprite player4;
    public Sprite player3;
    public Sprite player2;
    public Sprite player1;
    public Sprite player;

    // Start is called before the first frame update
    void Start()
    {
        health = GetComponent<Health>();
        spriteRend = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(currentHealth == health.health){
            return;
        }

        CheckHealth();
    }

    void CheckHealth()
    {
        switch (health.health)
        {
            case 4:
                currentHealth = 4;
                spriteRend.sprite = player4;
                break;
            case 3:
                currentHealth = 3;
                spriteRend.sprite = player3;
                break;
            case 2:
                currentHealth = 2;
                spriteRend.sprite = player2;
                break;
            case 1:
                currentHealth = 1;
                spriteRend.sprite = player1;
                break;
            case 0:
                currentHealth = 0;
                spriteRend.sprite = player;
                break;
            default:
                currentHealth = -1;
                spriteRend.sprite = player;
                break;
        }
    }
}
