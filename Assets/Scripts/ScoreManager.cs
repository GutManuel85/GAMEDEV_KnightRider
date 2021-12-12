using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    private int score = 0;
    public Text textScore;


    public void addScore()
    {
        score++;
        textScore.text = score.ToString();
    }


    public int getScore()
    {
        return score;
    }
}
