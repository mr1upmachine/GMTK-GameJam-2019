using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// valid color states
public enum ColorState { RED, GREEN, BLUE }
public enum GameState { MAIN_MENU, PLAY, PAUSE, GAME_OVER }

// Commenting out temporarily because I don't know what I wanna do with this atm
// public delegate void OnStateChangeHandler();

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;
    // public event OnStateChangeHandler OnStateChange;
    public GameState gameState { get; private set; }
    public ColorState colorState;
    public int scoreForStateChange = 1000;

    private int score;
    private int adjustedScore;

    public GameObject PauseMenu;

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
        PauseMenu.SetActive(false);

        // init the original color state to red on object start (post awake)
        colorState = ColorState.RED;

        // init total score
        score = 0;
    }

    void Update() {
        if(adjustedScore >= scoreForStateChange)
        {
            adjustedScore = 0;
            ChangeColorState();

        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseControl();
        }
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

    public void IncrementGameScore(int pointValue)
    {
        adjustedScore += pointValue;
        score += pointValue;
    }

    public void UpdateGameScore(int score)
    {
        if (score == this.score)
        {
            Debug.Log("Score was the same, not updating");
        }
        else
        {
            this.score = score;
        }
    }

    public int GetCurrentScore()
    {
        return score;
    }

    // controls the pausing of the scene
    public void PauseControl()
    {
        if (Time.timeScale == 1)
        {
            gameState = GameState.PAUSE;
            Time.timeScale = 0;
            PauseMenu.SetActive(true);
        }
        else if (Time.timeScale == 0)
        {
            gameState = GameState.PLAY;
            Time.timeScale = 1;
            PauseMenu.SetActive(false);
        }
    }
}
