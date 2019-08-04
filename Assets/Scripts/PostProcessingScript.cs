using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class PostProcessingScript : MonoBehaviour
{
    public PostProcessVolume volume;
    public Vignette vignette = null;
    private ColorParameter red = new ColorParameter();
    private ColorParameter blue = new ColorParameter();
    private ColorParameter green = new ColorParameter();
    private int currentState = 0;

    // Start is called before the first frame update
    void Start()
    {
        volume = gameObject.GetComponent<PostProcessVolume>();
        volume.profile.TryGetSettings<Vignette>(out vignette);
        red.value = Color.red;
        blue.value = Color.blue;
        green.value = Color.green;

        if (vignette != null)
        {
            switch(GameManager.instance.colorState)
            {
                case ColorState.RED:
                    if (currentState != 1)
                    {
                        Debug.Log("Changing color to red");
                        vignette.color.Override(Color.red);
                    }
                    currentState = 1;
                    break;
                case ColorState.BLUE:
                    if (currentState != 2)
                    {
                        Debug.Log("Changing color to blue");
                        vignette.color.Override(Color.blue);
                    }
                    currentState = 2;
                    break;
                case ColorState.GREEN:
                    if (currentState != 3)
                    {
                        Debug.Log("Changing color to green");
                        vignette.color.Override(Color.green);
                    }
                    currentState = 3;
                    break;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (vignette != null)
        {
            switch (GameManager.instance.colorState)
            {
                case ColorState.RED:
                    if (currentState != 1)
                    {
                        Debug.Log("Changing color to red");
                        vignette.color.Override(Color.red);
                    }
                    currentState = 1;
                    break;
                case ColorState.BLUE:
                    if (currentState != 2)
                    {
                        Debug.Log("Changing color to blue");
                        vignette.color.Override(Color.blue);
                    }
                    currentState = 2;
                    break;
                case ColorState.GREEN:
                    if (currentState != 3)
                    {
                        Debug.Log("Changing color to green");
                        vignette.color.Override(Color.green);
                    }
                    currentState = 3;
                    break;
            }
        }
    }
}
