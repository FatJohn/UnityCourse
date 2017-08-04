using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public float AutoLoadNextLevelAfterSeconds;

    private void Start()
    {
        if (AutoLoadNextLevelAfterSeconds <= 0)
        {
            return;
        }

        Invoke("LoadNextLevel", AutoLoadNextLevelAfterSeconds);
    }

    public void LoadLevel(string name)
    {
        Debug.Log("Load level " + name);
        SceneManager.LoadScene(name);
    }

    public void QuitRequest()
    {
        Application.Quit();
    }

    public void LoadNextLevel()
    {
        var activeScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(activeScene.buildIndex + 1);
    }
}
