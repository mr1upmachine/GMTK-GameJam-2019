using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class SceneManagerScript : MonoBehaviour
{
    public string nextScene;
    public string mainMenu;

    public bool hasPauseMenu;
    public bool hasGameOverMenu;
    public GameObject PauseMenu;
    public GameObject GameOverMenu;
    public TextMeshProUGUI score;
    public TextMeshProUGUI wave;
    public WaveManager waveManager;

    // This script will simply instantiate the Prefab when the game starts.
    void Start()
    {
        PlayGame();
        if (hasPauseMenu && PauseMenu == null) Instantiate(PauseMenu);
        if (hasGameOverMenu && GameOverMenu == null) Instantiate(GameOverMenu);

        score.text = GameManager.instance.GetCurrentScore().ToString();
        wave.text = waveManager.GetWaveNumber().ToString();
    }

    void Update()
    {
        if(GameManager.instance.gameState == GameState.GAME_OVER){
            GameOver();
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameManager.instance.gameState == GameState.PLAY)
            {
                PauseGame();
            }
            else
            {
                PlayGame();
            }
        }

        if (Input.GetKeyDown("r"))
        {
            ReloadCurrentScene();
        }

        if (GameManager.instance.GetCurrentScore() > int.Parse(score.text))
        {
            score.text = GameManager.instance.GetCurrentScore().ToString();
        }

        if (waveManager.GetWaveNumber() > int.Parse(wave.text))
        {
            wave.text = waveManager.GetWaveNumber().ToString();
        }
    }

    public void ReloadCurrentScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        GameManager.instance.PlayGame();
    }

    public void LoadNextScene()
    {
        if (nextScene != null)
        {
            SceneManager.LoadScene(nextScene);
        }
    }

    public void LoadMainMenu()
    {
        if (mainMenu != null)
        {
            SceneManager.LoadScene(mainMenu);
            GameManager.instance.PlayGame();
        }
    }

    public void GameOver()
    {
        if (GameOverMenu) GameOverMenu.SetActive(true);
    }

    public void PauseGame()
    {
        GameManager.instance.PauseGame();
        if (PauseMenu) PauseMenu.SetActive(true);
    }

    public void PlayGame()
    {
        GameManager.instance.PlayGame();
        if (PauseMenu) PauseMenu.SetActive(false);
    }
}
