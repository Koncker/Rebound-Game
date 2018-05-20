using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

    private PaddleController paddle;
    private Vector3 paddleToBallVector;
    Rigidbody2D ball;

    private AudioSource impact;

    bool hasStarted;

	void Start () {

        // Here we are setting our Prefab to find GameObject of Type PaddleController - To find the script with this name.
        paddle = GameObject.FindObjectOfType<PaddleController>();

        ball = GetComponent<Rigidbody2D>();

        // Here we receive the vector3 giving us the position between the ball and the paddle. This is used to receive what we will then use to keep the object static.
        paddleToBallVector = this.transform.position - paddle.transform.position;
        print(paddleToBallVector.y);

        impact = GetComponent<AudioSource>();
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (hasStarted) { 
            impact.Play();
        }
    }

    void Update ()
    {
        // Here we set to see if the game has started or not. It will only set when hasStarted = true, which is after the player clicks the mouse.
        if (!hasStarted)
        {
            // Here we keep the object static until we wish, by adding the position that we got above - Locks the ball relative to the paddle.
            this.transform.position = paddle.transform.position + paddleToBallVector;
        
            // Wait for a mouse press to Launch.
            if (Input.GetMouseButtonDown(0))
            {
                hasStarted = true;
                print("Mouse Clicked, Ball Launched");
                ball.velocity = new Vector2 (2f, 10f);
            }
        }
    }
}
