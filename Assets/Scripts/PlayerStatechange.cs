using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatechange : MonoBehaviour
{

    public Sprite redSprite;
    public Sprite greenSprite;
    public Sprite blueSprite;

    private SpriteRenderer spriteRender;
    private int currentSprite;

    // Start is called before the first frame update
    void Start()
    {
        spriteRender = GetComponent<SpriteRenderer>();

        //sets player sprite based on color state
        switch(GameManager.instance.colorState)
        {
            case ColorState.RED:
                spriteRender.sprite = redSprite;
                currentSprite = 1;
                break;
            case ColorState.GREEN:
                spriteRender.sprite = greenSprite;
                currentSprite = 2;
                break;
            case ColorState.BLUE:
                spriteRender.sprite = blueSprite;
                currentSprite = 3;
                break;
            default:
                Debug.Log("Can't find color state, defaulting to red!");
                spriteRender.sprite = redSprite;
                currentSprite = 1;
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //sets player sprite based on game state
        switch(GameManager.instance.colorState)
        {
            case ColorState.RED:
                if(currentSprite != 1){
                    spriteRender.sprite = redSprite;
                    currentSprite = 1;
                }
                break;
            case ColorState.GREEN:
                if(currentSprite != 2){
                    spriteRender.sprite = greenSprite;
                    currentSprite = 2;
                }
                break;
            case ColorState.BLUE:
                if(currentSprite != 3){
                    spriteRender.sprite = blueSprite;
                    currentSprite = 3;
                }
                break;
            default:
                Debug.Log("Can't find color state, defaulting to red!");
                if(currentSprite != 1){
                    spriteRender.sprite = redSprite;
                    currentSprite = 1;
                }
                break;
        }
    }
}
