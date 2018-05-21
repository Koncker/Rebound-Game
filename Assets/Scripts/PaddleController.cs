using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleController : MonoBehaviour {

    private Ball ball;
    public bool autoPlay = false;

    private void Start()
    {
        ball = GameObject.FindObjectOfType<Ball>();
        print(ball);
    }

    // Update is called once per frame
    void Update ()
    {
        if      (ball.hasStarted == true)       {Cursor.visible = false; Debug.Log("Cursor is now invisible");}
        else                                    {Cursor.visible = true; Debug.Log("Cursor is now visible");
        }

        if      (!autoPlay)                     {MoveWithMouse();}
        else                                    {AutoPlay();}
    }

    void MoveWithMouse()
    {
        // This allows me to set a Vector 3 to receive the values that I want. It also allows me to store values in it.
        Vector3 paddlePos = new Vector3(1f, this.transform.position.y, 0f);

        // This gives me the float of the users mouse position X. Divided by the screen width, gives me a value between 0 and 1, 
        // and finally dividing it by the screen width, allows me to move the number of blocks I wish.
        float mousePosInBlocks = Input.mousePosition.x / Screen.width * 16;

        // This will now hold the value from above, mousePosInBlocks and limit it with the Mathf.Clamp between 1 and 15. i.e. higher values will not be allowed.
        paddlePos.x = Mathf.Clamp(mousePosInBlocks, 1f, 15f);

        // Now here I make the paddle transform to the Left and Right using paddlePos, which only gives an x value.
        this.transform.position = paddlePos;
    }

    void AutoPlay()
    {
        Vector3 paddlePos = new Vector3(1f, this.transform.position.y, 0f);
        float ballPos = ball.transform.position.x;
        paddlePos.x = Mathf.Clamp(ballPos, 1f, 15f);
        this.transform.position = paddlePos;
    }
}
