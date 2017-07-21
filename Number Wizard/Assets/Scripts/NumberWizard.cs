using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumberWizard : MonoBehaviour
{
    private double max = 1000;
    private double min = 1;
    private int guess = 500;

	// Use this for initialization
	void Start()
    {
        StartGame();
    }

    private void StartGame()
    {
        print("==================================================");
        print("Welcome to Nubmer Wizard");
        print("Pick a number in your head, but don't tell me!");

        print("The highest nubmer you can pick is " + max);
        print("The lowest nubmer you can pick is " + min);

        print("Is the number higher or lower than " + guess + " ?");
        print("Up = higher, down = lower, return = equal");

        max = 1000;
        min = 1;
        guess = 500;
    }

    // Update is called once per frame
    void Update()
    {
		if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            min = guess;
            NextGuess();
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            max = guess;
            NextGuess();
        }
        else if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            print("I won!");
            StartGame();
        }
	}

    private void NextGuess()
    {
        guess = System.Convert.ToInt32((max + min) / 2);
        print("Higher or lower than " + guess + " ?");
        print("Up = higher, down = lower, return = equal");
    }
}
