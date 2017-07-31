using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreKeeper : MonoBehaviour
{
    public static int TotalScore;
    private Text scoreText;

    private void Start()
    {
        scoreText = GetComponent<Text>();
        Reset();
    }

    public void Score(int points)
    {
        TotalScore += points;
        scoreText.text = TotalScore.ToString();
    }

    public static void Reset()
    {
        TotalScore = 0;
    }
}
