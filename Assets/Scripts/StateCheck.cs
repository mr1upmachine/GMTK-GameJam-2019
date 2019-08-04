using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateCheck : MonoBehaviour
{
    public Sprite activeSprite;
    public Sprite inactiveSprite;

    private ColorState currentState;
    private Vector2 velocity;
    private float mass;
    public bool isDisabled = false;

    private SpriteRenderer spriteRender;
    private Rigidbody2D body;
    private Collider2D collision;

    // Start is called before the first frame update
    void Start()
    {
        spriteRender = GetComponent<SpriteRenderer>();
        body = GetComponent<Rigidbody2D>();
        collision = GetComponent<Collider2D>();

        CheckState();
    }

    void FixedUpdate()
    {
        if (currentState == GameManager.instance.colorState) return;

        CheckState();
    }

    void CheckState()
    {
        //Checks the object tag and compares with current color state
        switch (GameManager.instance.colorState)
        {
            case ColorState.RED:
                currentState = ColorState.RED;
                if (gameObject.tag == "RED")
                {
                    activate();
                    return;
                }
                break;
            case ColorState.GREEN:
                currentState = ColorState.GREEN;
                if (gameObject.tag == "GREEN")
                {
                    activate();
                    return;
                }
                break;
            case ColorState.BLUE:
                currentState = ColorState.BLUE;
                if (gameObject.tag == "BLUE")
                {
                    activate();
                    return;
                }
                break;
        }

        deactivate();
    }

    //Restores previous velocity, changes sprite, and re-enables collision
    void activate()
    {
        if (isDisabled)
        {
            spriteRender.sprite = activeSprite;
            collision.enabled = true;
            body.velocity = velocity;
            body.mass = 3;
            isDisabled = false;
            transform.position = new Vector3(transform.position.x, transform.position.y, 0f);
        }
    }

    //Changes sprite, stores current velocity, then freezes object and disables collsion
    void deactivate()
    {
        if (!isDisabled){
            spriteRender.sprite = inactiveSprite;
            velocity = body.velocity;
            collision.enabled = false;
            body.velocity = new Vector2(0,0);
            body.mass = 100000f;
            isDisabled = true;
            transform.position = new Vector3(transform.position.x, transform.position.y, 1f);
        }
    }
}