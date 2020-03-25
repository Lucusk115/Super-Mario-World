using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestoyObject : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
     void OnTriggerEnter2D(UnityEngine.Collider2D c)
    {
        if (c.gameObject.tag == "Player")
        {
        Destroy(this.gameObject);
        }

    }
}
