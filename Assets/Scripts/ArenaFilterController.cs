using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArenaFilterController : MonoBehaviour
{
    ColorState currentState;
    SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        currentState = GameManager.instance.colorState;
        spriteRenderer = GetComponent<SpriteRenderer>(); // we are accessing the SpriteRenderer that is attached to the Gameobject
    }

    // Update is called once per frame
    void Update()
    {
        if (currentState == GameManager.instance.colorState) return;

        currentState = GameManager.instance.colorState;

        if (currentState == ColorState.RED)
        {
            spriteRenderer.color = new Color(1, 0, 0, 0.2f);
        }
        else if (currentState == ColorState.GREEN)
        {
            spriteRenderer.color = new Color(0, 1, 0, 0.1f);
        }
        else // if state is BLUE
        {
            spriteRenderer.color = new Color(0, 0, 1, 0.1f);
        }
        Debug.Log(spriteRenderer.color);
    }
}
