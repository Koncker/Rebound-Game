﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

    public void LoadLevel(string name)
    {
        Brick.breakableCount = 0;
        Debug.Log("Level load requested for: " + name);
        SceneManager.LoadScene(name);
    }

    public void BrickDestroyed()
    {
        if (Brick.breakableCount <= 0) // Make it less than 0, just in case it goes negative.
        {
            LoadNextLevel();
        }
    }

    public void LoadNextLevel()
    {
        // Used to get the current scene in the buildIndex and add 1 to it to go to the next scene.
        Brick.breakableCount = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitRequest()
    {
        Application.Quit();
    }

}
