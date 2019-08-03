using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// valid color states
public enum ColorState { RED, GREEN, BLUE }
public enum GameState { MAIN_MENU, GAME_OVER }

public delegate void OnStateChangeHandler();

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;
    public event OnStateChangeHandler OnStateChange;
    public GameState gameState { get; private set; }
    public ColorState colorState;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        // init the original color state to red on object start (post awake)
        colorState = ColorState.RED;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeColorState()
    {
        if (colorState == ColorState.RED)
        {
            colorState = ColorState.GREEN;
        }
        else if (colorState == ColorState.GREEN)
        {
            colorState = ColorState.BLUE;
        }
        else
        {
            // if state is BLUE
            colorState = ColorState.RED;
        }
    }

}
