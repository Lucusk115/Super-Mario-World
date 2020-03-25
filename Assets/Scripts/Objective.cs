using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objective : MonoBehaviour {

    // Used to keep a reference to Player GameObject
    public GameObject player;

    // Used to keep track of Collectibles left
    public GameObject[] collectibles;

    // Used to keep track of number of Collectibles
    public int numberOfCollectibles;

    // Used to keep a reference to finishLine GameObject
    public GameObject finishLine;

	// Use this for initialization
	void Start () {

        // Looks through Scene for a GameObject named "Mario" in Hierarchy
        // - GameObject must be active 
        player = GameObject.Find("Mario");

        // Looks through Scene for a GameObject tagged "Player"
        // - GameObject must be active
        player = GameObject.FindGameObjectWithTag("Player");

        // Looks through entire Scene for GameObjects tagged as "Collectible"
        // - Returns everything active that is tagged as "Collectible"
        // - Typically found in order they were added to Scene
        // - Should be used sparingly and only in Start() or Awake()
        collectibles = GameObject.FindGameObjectsWithTag("Collectible");

        // Stores number of GameObjects
        numberOfCollectibles = collectibles.Length;

        // Looks through Scene for a GameObject named "Objective" in Hierarchy
        // - GameObject must be active 
        finishLine = GameObject.Find("Objective");
    }
	
	// Update is called once per frame
	void Update () {
		
        // Check if "Player" GameObject and "FinishLine" GameObject were found
        if(player && finishLine)
        {
            // Calculate distance between two Vectors using method Distance()
            float distanceToFinish = Vector2.Distance(
                player.transform.position, finishLine.transform.position);

            // Calculate distance between two Vectors using Vector math 
            distanceToFinish = (finishLine.transform.position
                - player.transform.position).magnitude;

            // Print distance to finish to debug. Not needed after you find out it works.
           //Debug.Log(distanceToFinish);
        }

	}
}
