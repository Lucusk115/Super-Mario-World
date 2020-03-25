﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Turret : MonoBehaviour {

    // Handle projectile Instantiation (aka Creation)
    public Transform projectileSpawnPoint;
    public Projectile projectilePrefab;
    public float projectileForce;

    // Handles projectile mechanic (rate of fire)
    public float projectileFireRate;
    float timeSinceLastFire = 0.0f;

    // Handles 'Enemy' health
    public int health;

    // Use this for initialization
    void Start () {
        // Checks if projectileSpawnPoint GameObject is connected
        if (!projectileSpawnPoint)
        {
            // Prints a message to Console (Shortcut: Control+Shift+C)
            Debug.LogError("No projectileSpawnPoint found on GameObject");
        }

        // Checks if projectileSpawnPoint GameObject is connected
        if (!projectilePrefab)
        {
            // Prints a message to Console (Shortcut: Control+Shift+C)
            Debug.LogError("No projectilePrefab found on GameObject");
        }

        // Check if 'projectileForce' was set to something not 0
        if (projectileForce == 0)
        {
            // Assign a default value if one is not set in the Inspector
            projectileForce = 7.0f;

            // Prints a message to Console (Shortcut: Control+Shift+C)
            Debug.Log("projectileForce was not set. Defaulting to " + projectileForce);
        }

        // Check if 'projectileFireRate' was set to something not 0
        if (projectileFireRate == 0)
        {
            // Assign a default value if one is not set in the Inspector
            projectileFireRate = 2.0f;

            // Prints a message to Console (Shortcut: Control+Shift+C)
            Debug.Log("projectileFireRate was not set. Defaulting to " + projectileFireRate);
        }

        // Check if 'health' was set to something not 0
        if (health == 0)
        {
            // Assign a default value if one is not set in the Inspector
            health = 5;

            // Prints a message to Console (Shortcut: Control+Shift+C)
            Debug.Log("health was not set. Defaulting to " + health);
        }
    }
	
	// Update is called once per frame
	void Update () {
        // Check if enough time has passed before firing another projectile
        if (Time.time > timeSinceLastFire + projectileFireRate)
        {
            // Fire a projectile
            fire();

            // Timestamp of last time the projectile was fired
            timeSinceLastFire = Time.time;
        }
    }

    // Function used to create and fire a Projectile
    void fire()
    {
        // Creates Projectile and add its to the Scene
        // - projectPrefab is the thing to create
        // - projectileSpawnPoint is where and what rotation to use when created
        Projectile temp =
            Instantiate(projectilePrefab, projectileSpawnPoint.position, projectileSpawnPoint.rotation);

        /*temp.GetComponent<Rigidbody2D>().velocity =
            new Vector2(projectileForce, 0);

        temp.GetComponent<Rigidbody2D>().velocity =
            Vector2.right * projectileForce;
        */

        // Apply movement speed to Projectile that is spawned
        // - Lets the projectile handle its own movement
        temp.speed = projectileForce;
    }

    // Check for collisions with other GameObjects
    // - One or both GameObjects must have a Rigidbody2D attached
    // - Both need colliders attached
    private void OnCollisionEnter2D(Collision2D c)
    {
        // Check if 'Enemy' was hit by a 'Projectile'
        if(c.gameObject.tag == "Projectile")
        {
            // Remove one health point
            health--;
            // health -= c.gameObject.GetComponent<Projectile>().GetDamage();

            // Check if 'Enemy' has health
            if(health <= 0)
            {
                // Kill 'Enemy;
                // - Play Sound
                // - Trigger Respawn
                // - Play an Animation
                // - Etc...

                // 'Enemy' is dead, remove from Scene
                Destroy(gameObject);
            }
        }
    }
}
