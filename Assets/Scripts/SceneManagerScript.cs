using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneManagerScript : MonoBehaviour
{
    public string nextScene;
    public string gameOver;
    public string mainMenu;

    public void LoadNextScene()
    {
        if (nextScene != null)
        {
            SceneManager.LoadScene(nextScene);
        }
    }

    public void LoadGameOver()
    {
        if (nextScene != null)
        {
            SceneManager.LoadScene(gameOver);
        }
    }

    public void LoadMainMenu()
    {
        if (mainMenu != null)
        {
            SceneManager.LoadScene(mainMenu);
        }
    }
}
