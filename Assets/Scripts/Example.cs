using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioListener))]
public class Example : MonoBehaviour
{
  

    public Rigidbody2D myGameObject;
    public GameObject[] Collectible;
    public Character character;


    // Start is called before the first frame update
    void Start()
    {
        //finds game object Mario and assigns it to the new game object. Find by object name
        // myGameObject = GameObject.Find("Sprite_Mario_0").GetComponent<Rigidbody2D>();

        //find the first object under the tag named Player
        // myGameObject = GameObject.FindWithTag("Player").GetComponent<Rigidbody2D>();

        // uses casting to convert object to a rigidbody2D
        //myGameObject = (Rigidbody2D)FindObjectOfType(typeof(Rigidbody2D));

       Collectible = GameObject.FindGameObjectsWithTag("Collectible");

        character = FindObjectOfType<Character>();

        gameObject.AddComponent<AudioSource>();


        Vector2 v1 = new Vector2(45, 6);
        Vector2 v2 = new Vector2(56, 23);

        float distance = Vector2.Distance(v1, v2);
        Debug.Log(distance);

        float dot = Vector2.Dot(v1, v2);

        if (dot < 0)
        {
            Debug.Log("behind");
        }
        else if (dot > 0)
        {
            Debug.Log("ahead");
        }


    }

    // Update is called once per frame
    void Update()
    {
       /* foreach (Transform t in transform)
        {
            t.Translate(0, 0, 0);
        }*/
    }

    //This trigger grabs collectible and fires a projectile at the same time
    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.GetComponent<Character>().fire();
    }
}
