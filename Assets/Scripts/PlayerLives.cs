using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerLives : MonoBehaviour {
    public int playerLives;

    static PlayerLives instance = null;
    public Text text;

    private void Start()
    {
        playerLives = 3;

        if (instance != null)
        {
            Destroy(gameObject);
            Debug.Log("Duplicate music player self-destructing!");
        }
        // Therefore, instance is now the static and the only one that is meant to exist. This will only run once as we have DontDestroyOnLoad.
        else
        {
            instance = this;
            GameObject.DontDestroyOnLoad(gameObject);
        }
    }

    public void LivesTextPrint()
    {
//        text.text = "" + playerLives;
    }

}
