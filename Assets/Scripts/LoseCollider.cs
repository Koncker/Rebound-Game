using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseCollider : MonoBehaviour {

    private Ball ball;
    private LevelManager levelManager;

    private void Start()
    {
        // Here we are setting our Prefab to find GameObject of Type LevelManager - To find the script with this name.
        levelManager =  GameObject.FindObjectOfType<LevelManager>();
        ball =          GameObject.FindObjectOfType<Ball>();
    }

    private void OnTriggerEnter2D(Collider2D trigger)
    {
        print("Triggered");
        levelManager.LoadLevel("Lose");
        Debug.Log("Player Lost - Loading level");
        Destroy(trigger.gameObject);
        ball.hasStarted = false;
    }
}
