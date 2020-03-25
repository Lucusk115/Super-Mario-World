using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Enemy_Walker : MonoBehaviour {

    // Reference Rigidbody2D through script
    Rigidbody2D rb;

    // Handle movement speed of Character
    // - Can be adjusted through Inspector while in Play mode
    public float speed;

    // Handles Character flipping
    public bool isFacingRight;

    // Use this for initialization
    void Start () {
        // Reference Rigidbody through script
        rb = GetComponent<Rigidbody2D>();

        // Checks if Component exists
        if (!rb)
        {
            // Prints a message to Console (Shortcut: Control+Shift+C)
            Debug.LogWarning("No Rigidbody2D found.");
        }

        // Check if speed was set to something not 0
        if (speed <= 0)
        {
            // Assign a default value if one is not set in the Inspector
            speed = 5.0f;

            // Prints a message to Console (Shortcut: Control+Shift+C)
            Debug.LogWarning("Default speed to " + speed);
        }
    }
	
	// Update is called once per frame
	void Update () {

        // Check if Enemy is facing right
        if (!isFacingRight)
            // Move Enemy Left
            rb.velocity = new Vector2(-speed, rb.velocity.y);
        else
            // Move Enemy Right
            rb.velocity = new Vector2(speed, rb.velocity.y);

    }

    // Check for collisions with other GameObjects
    // - One or both GameObjects must have a Rigidbody2D attached
    // - Both need colliders attached
    // - Must have 'Is Trigger' checked on the Collider2D
    private void OnTriggerEnter2D(Collider2D c)
    {
        // Check if Enemy hit a barrier
        if (c.gameObject.tag == "Enemy_Barrier")
            // Flip Enemy
            flip();
    }

    // Check for collisions with other GameObjects
    // - One or both GameObjects must have a Rigidbody2D attached
    // - Both need colliders attached
    private void OnCollisionEnter2D(Collision2D c)
    {
        // Check if Enemy hits something else
        if (c.gameObject.tag == "Enemy" || c.gameObject.tag == "Player")
            // Flip Enemy
            flip();
    }

    // Function used to flip direction GameObject (Character) is facing
    void flip()
    {
        // Toggle isFacingRight variable
        isFacingRight = !isFacingRight;

        // Make a copy of old scale value
        Vector3 scaleFactor = transform.localScale;

        // Flip scale of 'x' variable
        scaleFactor.x *= -1;    // scaleFactor.x = -scaleFactor.x;

        // Update scale to new flipped value
        transform.localScale = scaleFactor;
    }
}
