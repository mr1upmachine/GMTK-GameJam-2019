using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateCheck : MonoBehaviour
{
    public Sprite activeSprite;
    public Sprite inactiveSprite;
    private int currentState = 0;
    private Vector2 velocity;
    private float mass;
    private bool hasBeenDisabled = false;

    private SpriteRenderer spriteRender;
    private Rigidbody2D body;
    private Collider2D collision;

    // Start is called before the first frame update
    void Start()
    {
        spriteRender = GetComponent<SpriteRenderer>();
        body = GetComponent<Rigidbody2D>();
        collision = GetComponent<Collider2D>();

        //Checks the object tag and compares with current color state
        switch(GameManager.instance.colorState)
        {
            case ColorState.RED:
                if(gameObject.tag.Contains("RED") && currentState != 1){
                    activate();
                }else if(!gameObject.tag.Contains("RED") && currentState != 1){
                    deactivate();
                }
                currentState = 1;
                break;
            case ColorState.GREEN:
                if(gameObject.tag.Contains("GREEN") && currentState != 2){
                    activate();
                }else if(!gameObject.tag.Contains("GREEN") && currentState != 2){
                    deactivate();
                }
                currentState = 2;
                break;
            case ColorState.BLUE:
                if(gameObject.tag.Contains("BLUE") && currentState != 3){
                    activate();
                }else if(!gameObject.tag.Contains("BLUE") && currentState != 3){
                    deactivate();
                }
                currentState = 3;
                break;
            default:
                Debug.Log("Can't find color state, defaulting to red!");
                if(gameObject.tag.Contains("RED")){
                    activate();
                }else if(!gameObject.tag.Contains("RED")){
                    deactivate();
                }
                currentState = 1;
                break;
        }
    }

    void FixedUpdate()
    {
        //Checks the object tag and compares with current color state
        switch(GameManager.instance.colorState)
        {
            case ColorState.RED:
                if(gameObject.tag.Contains("RED") && currentState != 1){
                    activate();
                }else if(!gameObject.tag.Contains("RED") && currentState != 1){
                    deactivate();
                }
                currentState = 1;
                break;
            case ColorState.GREEN:
                if(gameObject.tag.Contains("GREEN") && currentState != 2){
                    activate();
                }else if(!gameObject.tag.Contains("GREEN") && currentState != 2){
                    deactivate();
                }
                currentState = 2;
                break;
            case ColorState.BLUE:
                if(gameObject.tag.Contains("BLUE") && currentState != 3){
                    activate();
                }else if(!gameObject.tag.Contains("BLUE") && currentState != 3){
                    deactivate();
                }
                currentState = 3;
                break;
            default:
                Debug.Log("Can't find color state, defaulting to red!");
                if(gameObject.tag.Contains("RED")){
                    activate();
                }else if(!gameObject.tag.Contains("RED")){
                    deactivate();
                }
                currentState = 1;
                break;
        }
    }

    //Restores previous velocity, changes sprite, and re-enables collision
    void activate()
    {
        if(hasBeenDisabled)
        {
            spriteRender.sprite = activeSprite;
            collision.enabled = true;
            body.velocity = velocity;
            body.mass = mass;
            hasBeenDisabled = false;
        }
    }

    //Changes sprite, stores current velocity, then freezes object and disables collsion
    void deactivate()
    {
        if(!hasBeenDisabled){
            spriteRender.sprite = inactiveSprite;
            velocity = body.velocity;
            mass = body.mass;
            collision.enabled = false;
            body.velocity = new Vector2(0,0);
            body.mass = 100000f;
            hasBeenDisabled = true;
        }
    }
}