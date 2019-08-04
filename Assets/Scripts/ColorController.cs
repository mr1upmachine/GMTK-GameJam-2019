using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorController : MonoBehaviour
{
    public Sprite red;
    public Sprite green;
    public Sprite blue;
    public float timer = .75f;

    private ColorState currentState;
    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        currentState = ColorState.RED;
        spriteRenderer = GetComponent<SpriteRenderer>(); // we are accessing the SpriteRenderer that is attached to the Gameobject
        if (spriteRenderer.sprite == null) // if the sprite on spriteRenderer is null then
            spriteRenderer.sprite = red; // set the sprite to sprite1

        InvokeRepeating("toggleColor", timer, timer);
    }

    private void toggleColor()
    {
        if (currentState == ColorState.RED)
        {
            SetGreen();
        }
        else if (currentState == ColorState.GREEN)
        {
            SetBlue();
        }
        else // if state is BLUE
        {
            SetRed();
        }
    }

    void SetRed()
    {
        spriteRenderer.sprite = red;
        currentState = ColorState.RED;
    }

    void SetBlue()
    {
        spriteRenderer.sprite = blue;
        currentState = ColorState.BLUE;
    }

    void SetGreen()
    {
        spriteRenderer.sprite = green;
        currentState = ColorState.GREEN;
    }
}
