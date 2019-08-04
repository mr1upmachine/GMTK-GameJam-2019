using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorController : MonoBehaviour
{
    public Sprite red;
    public Sprite green;
    public Sprite blue;

    private ColorState currentState;
    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        currentState = GameManager.instance.colorState;
        spriteRenderer = GetComponent<SpriteRenderer>(); // we are accessing the SpriteRenderer that is attached to the Gameobject
        if (spriteRenderer.sprite == null) // if the sprite on spriteRenderer is null then
            spriteRenderer.sprite = red; // set the sprite to sprite1
    }

    private void Update()
    {
        if (currentState != GameManager.instance.colorState)
        {
            currentState = GameManager.instance.colorState;

            if (currentState == ColorState.RED)
            {
                SetRed();
            }
            else if (currentState == ColorState.GREEN)
            {
                SetBlue();
            }
            else // if state is BLUE
            {
                SetGreen();
            }
        }
    }

    void SetRed()
    {
        spriteRenderer.sprite = red;
    }

    void SetBlue()
    {
        spriteRenderer.sprite = blue;
    }

    void SetGreen()
    {
        spriteRenderer.sprite = green;
    }
}
