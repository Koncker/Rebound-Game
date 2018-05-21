using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour {

    public Sprite[] hitSprites;
    public static int breakableCount = 0;

    private int timesHit;
    private LevelManager levelManager;
    private bool isBreakable;

    public AudioClip destroyed;

    void Start ()
    {
        // If it is breakable - it will appear here. Each brick if it is breakable.
        isBreakable = (this.tag == "BreakableBlock");

        // To track breakable bricks - Then it will appear here.
        if (isBreakable)
        {
            breakableCount++;
            Debug.Log(breakableCount);
        }

        // Here we are setting our Prefab to find GameObject of Type LevelManager - To find the script with this name.
        levelManager = GameObject.FindObjectOfType<LevelManager>();

        timesHit = 0;
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // This puts the audiosource where the object is. This allows us to destroy the object and still have the audio playing.
        AudioSource.PlayClipAtPoint(destroyed, transform.position);
        if (isBreakable) { 
            HandleHits();
        }
    }

    void HandleHits()
    {
        timesHit = timesHit + 1; //Another way to write this is timesHit++

        int maxHits = hitSprites.Length + 1;

        if (timesHit >= maxHits)
        {
            breakableCount--; // Decrease breakableCount by 1 before it is destroyed.
            Debug.Log(breakableCount);
            levelManager.BrickDestroyed(); // We tell LevelManager that a brick has been destroyed.
            Destroy(gameObject);
        }
        else { LoadSprites(); }
    }

    void LoadSprites()
    {
        // The sprite index we want to load is the timesHit - 1 as Sprite Element is 0 and not 1.

        int spriteIndex = timesHit - 1;

        // We use "this" and GetComponent Sprite Renderer and put the Sprite Element into the Sprite Renderer 
        // -> We tell the code to change the sprite in the Sprite Renderer according to our element in hitSprites and the integer we defined above.

        if (hitSprites[spriteIndex]) { // This code makes it so if we forget to add a sprite to the sprite index, it doesn't become invisible.
            this.GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
        }
    }

    // TODO Remove this Method once we can actually win!
    void SimulateWin()
    {
        levelManager.LoadNextLevel();
    }
}
