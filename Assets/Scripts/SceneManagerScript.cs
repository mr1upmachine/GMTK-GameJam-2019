using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneManagerScript : MonoBehaviour
{
    public Scene nextScene;
    public Scene gameOver;
    public Scene mainMenu;

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
            SceneManager.LoadScene(nextScene.buildIndex);
        }
    }
    
    public void LoadGameOver()
    {
        if (nextScene != null)
        {
            SceneManager.LoadScene(gameOver.buildIndex);
        }
    }

    public void LoadMainMenu()
    {
        if (mainMenu != null)
        {
            SceneManager.LoadScene(mainMenu.buildIndex);
        }
    }


}
