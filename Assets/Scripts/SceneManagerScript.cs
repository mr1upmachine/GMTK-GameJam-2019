using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneManagerScript : MonoBehaviour
{
    public string nextScene;
    public string mainMenu;

    public bool hasPauseMenu;
    public bool hasGameOverMenu;
    public GameObject PauseMenu;
    public GameObject GameOverMenu;

    // This script will simply instantiate the Prefab when the game starts.
    void Start()
    {
        PlayGame();
        if (hasPauseMenu && PauseMenu == null) Instantiate(PauseMenu);
        if (hasGameOverMenu && GameOverMenu == null) Instantiate(GameOverMenu);
    }

    void Update()
    {
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
