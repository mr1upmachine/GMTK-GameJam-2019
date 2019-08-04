using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeState : MonoBehaviour
{
    public void ChangeTheState()
    {
        GameManager.instance.ChangeColorState();
    }
}
