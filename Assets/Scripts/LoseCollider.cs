using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseCollider : MonoBehaviour {

    private Ball ball;
    private LevelManager levelManager;
    private PlayerLives lives;

    private void Start()
    {
        // Here we are setting our Prefab to find GameObject of Type LevelManager - To find the script with this name.
        levelManager =  GameObject.FindObjectOfType<LevelManager>();
        ball =          GameObject.FindObjectOfType<Ball>();
        lives =         GameObject.FindObjectOfType<PlayerLives>();
    }

    private void OnTriggerEnter2D(Collider2D trigger)
    {
        if (lives.playerLives <= 0) {
            Destroy(lives);
            print("Triggered");
            levelManager.LoadLevel("Lose");
            Debug.Log("Player Lost - Loading level");
            Destroy(trigger.gameObject);
            ball.hasStarted = false;
        }

        else
        {
            Brick.breakableCount = 0;
            lives.playerLives--;
            lives.LivesTextPrint();
            Debug.Log(lives.playerLives);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        } 
    }
}
