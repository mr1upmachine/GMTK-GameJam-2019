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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

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
