using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// High Score Manager will be a Singleton object
// use HighScoreManager.instance to access functions and variables


public class HighScoreManager : MonoBehaviour
{
    public static HighScoreManager instance = null;
    private const int leaderboardLength = 10;

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

    public void SaveHighScore (string name, int score)
    {
        List<Scores> HighScores = new List<Scores>();

        int i = 0;
        while(i < leaderboardLength && PlayerPrefs.HasKey("HighScore" + i + "score"))
        {
            Scores temp = new Scores();
            temp.score = PlayerPrefs.GetInt("HighScore" + i + "score");
            temp.name = PlayerPrefs.GetString("HighScore" + i + "name");
            HighScores.Add(temp);
            i++;
        }
        if (HighScores.Count == 0)
        {
            Scores temp = new Scores();
            temp.score = score;
            temp.name = name;
            HighScores.Add(temp);
        }
        else
        {
            for(i = 1; i <= HighScores.Count && i <= leaderboardLength; i++)
            {
                if (score > HighScores[i - 1].score)
                {
                    Scores temp = new Scores();
                    temp.name = name;
                    temp.score = score;
                    HighScores.Insert(i - 1, temp);
                    break;
                }
                if (i == HighScores.Count && i < leaderboardLength)
                {
                    Scores temp = new Scores();
                    temp.name = name;
                    temp.score = score;
                    HighScores.Add(temp);
                    break;
                }
            }
        }

        i = 1;
        while(i <= leaderboardLength && i <= HighScores.Count)
        {
            PlayerPrefs.SetString("HighScore" + i + "name", HighScores[i - 1].name);
            PlayerPrefs.SetInt("HighScore" + i + "name", HighScores[i - 1].score);
            i++;
        }
    }



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public class Scores
    {
        public int score;
        public string name;
    }
}
