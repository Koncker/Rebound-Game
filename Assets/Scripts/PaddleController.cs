using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
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
}
