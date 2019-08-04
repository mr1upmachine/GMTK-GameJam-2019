using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarpColorSwitch : MonoBehaviour
{
        private ColorState currentState;
        private GameObject warpRed;
        private GameObject warpGreen;
        private GameObject warpBlue;

    // Start is called before the first frame update
    void Start()
    {
        warpRed = transform.Find("WarpRed").gameObject;
        warpGreen = transform.Find("WarpGreen").gameObject;
        warpBlue = transform.Find("WarpBlue").gameObject;
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
                warpRed.GetComponent<ParticleSystem>().Play();
                warpBlue.GetComponent<ParticleSystem>().Stop();
                warpGreen.GetComponent<ParticleSystem>().Stop();
                break;
            case ColorState.GREEN:
                currentState = ColorState.GREEN;
                warpRed.GetComponent<ParticleSystem>().Stop();
                warpGreen.GetComponent<ParticleSystem>().Play();
                warpBlue.GetComponent<ParticleSystem>().Stop();
                break;
            case ColorState.BLUE:
                warpGreen.GetComponent<ParticleSystem>().Stop();
                warpBlue.GetComponent<ParticleSystem>().Play();
                warpRed.GetComponent<ParticleSystem>().Stop();
                break;
        }
    }

}
