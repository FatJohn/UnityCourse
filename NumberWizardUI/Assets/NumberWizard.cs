using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NumberWizard : MonoBehaviour
{
    private int max = 1000;
    private int min = 1;
    private int guess = 500;
    private int guessCount = 0;

    public Text foobar;

    public int maxGuessAllowed = 5;

    void Start()
    {
        StartGame();
    }

    private void StartGame()
    {
        max = 1000;
        min = 1;
        NextGuess();
        guessCount = 0;
    }

    public void GuessHigher()
    {
        min = guess;
        NextGuess();
    }

    public void GuessLower()
    {
        max = guess;
        NextGuess();
    }

    private void NextGuess()
    {
        guess = Convert.ToInt32(UnityEngine.Random.Range(min, max + 1));
        foobar.text = guess.ToString();
        guessCount++;

        if (guessCount >= maxGuessAllowed)
        {
            SceneManager.LoadScene("Win");
        }
    }
}
