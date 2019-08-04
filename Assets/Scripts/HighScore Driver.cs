using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScoreDriver : MonoBehaviour
{
    public Text player1;
    public Text player1score;
    public Text player2;
    public Text player2score;
    public Text player3;
    public Text player3score;
    public Text player4;
    public Text player4score;
    public Text player5;
    public Text player5score;
    public Text player6;
    public Text player6score;
    public Text player7;
    public Text player7score;
    public Text player8;
    public Text player8score;

    void Start()
    {
        List<HighScoreManager.Scores> scores = HighScoreManager.instance.GetHighScores();
        
        for (int i = 0; i <= scores.Count; i++)
        {
            switch(i)
            {
                case 0:
                    player1.text = scores[i].name;
                    player1score.text = scores[i].score.ToString();
                    break;
                case 1:
                    player2.text = scores[i].name;
                    player2score.text = scores[i].score.ToString();
                    break;
                case 2:
                    player3.text = scores[i].name;
                    player3score.text = scores[i].score.ToString();
                    break;
                case 3:
                    player4.text = scores[i].name;
                    player4score.text = scores[i].score.ToString();
                    break;
                case 4:
                    player5.text = scores[i].name;
                    player5score.text = scores[i].score.ToString();
                    break;
                case 5:
                    player6.text = scores[i].name;
                    player6score.text = scores[i].score.ToString();
                    break;
                case 6:
                    player7.text = scores[i].name;
                    player7score.text = scores[i].score.ToString();
                    break;
                case 7:
                    player8.text = scores[i].name;
                    player8score.text = scores[i].score.ToString();
                    break;
                default:
                    break;
            }
        }
    }
}
