using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundStates : MonoBehaviour
{
    private ColorState currentState;
    private Camera cam;

    public Color redColor;
    public Color greenColor;
    public Color blueColor;

    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<Camera>();
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
                cam.backgroundColor = redColor;
                break;
            case ColorState.GREEN:
                currentState = ColorState.GREEN;
                cam.backgroundColor = greenColor;
                break;
            case ColorState.BLUE:
                currentState = ColorState.BLUE;
                cam.backgroundColor = blueColor;
                break;
        }
    }

}
