using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    private static MusicManager instance;
    public AudioSource[] audioSources;
    public int current;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(instance);
        }
        else
        {
            Destroy(gameObject);
        }
        foreach(AudioSource i in audioSources)
        {
            i.Play();
            i.loop = true;
            i.volume = 0;
        }
        audioSources[0].volume = 1;
        current = 0;
    }
    // Update is called once per frame
    void Update()
    {
        if(getCurrentSong() != current)
        {
            audioSources[current].volume = 0;
            audioSources[getCurrentSong()].volume = 1;
            current = getCurrentSong();
        }
    }

    public int getCurrentSong()
    {
        if (GameManager.instance.gameState == GameState.MAIN_MENU)
        {
            return 0;
        }
        else if (GameManager.instance.gameState == GameState.PLAY && GameManager.instance.colorState == ColorState.BLUE)
        {
            return 1;
        }
        else if ((GameManager.instance.gameState == GameState.PAUSE || GameManager.instance.gameState == GameState.GAME_OVER) && GameManager.instance.colorState == ColorState.BLUE)
        {
            return 4;
        }
        else if (GameManager.instance.gameState == GameState.PLAY && GameManager.instance.colorState == ColorState.GREEN)
        {
            return 2;
        }
        else if ((GameManager.instance.gameState == GameState.PAUSE || GameManager.instance.gameState == GameState.GAME_OVER) && GameManager.instance.colorState == ColorState.GREEN)
        {
            return 5;
        }
        else if (GameManager.instance.gameState == GameState.PLAY && GameManager.instance.colorState == ColorState.RED)
        {
            return 3;
        }
        else if ((GameManager.instance.gameState == GameState.PAUSE || GameManager.instance.gameState == GameState.GAME_OVER) && GameManager.instance.colorState == ColorState.RED)
        {
            return 6;
        }
        else
        {
            return 0;
        }
    }
}
