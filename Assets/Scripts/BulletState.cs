using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletState : MonoBehaviour
{
    private ColorState currentState;

    // Start is called before the first frame update
    void Start()
    {
        CheckState();
    }

    // Update is called once per frame
    void Update()
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
                if(!gameObject.tag.Equals("RED")) {
                    Destroy(gameObject);
                }
                break;
            case ColorState.GREEN:
                currentState = ColorState.GREEN;
                if(!gameObject.tag.Equals("GREEN")) {
                    Destroy(gameObject);
                }
                break;
            case ColorState.BLUE:
                currentState = ColorState.BLUE;
                if(!gameObject.tag.Equals("BLUE")) {
                    Destroy(gameObject);
                }
                break;
        }
    }

}
