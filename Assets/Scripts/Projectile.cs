using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    public float speed;
    public float lifeTime = 10;
    // Start is called before the first frame update
    void Start()
    {

        if (speed <= 7 && speed >= 0)
        {
            speed = 7.0f;
            Debug.Log("speed was not set." +
            "Defaulting to " + speed);
 }
        else if (speed > -7 && speed < 0)
        {
            speed = -7.0f;
        }
            if (lifeTime <= 0)
        {
            lifeTime = 1.0f;
            Debug.Log("lifeTime was not set." +
            " Defaulting to " + lifeTime);
        }
        GetComponent<Rigidbody2D>().velocity = new Vector2(speed, 0);
        Destroy(gameObject, lifeTime);
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnCollisionEnter2D(UnityEngine.Collision2D c)
    {
        Destroy(this.gameObject);
    }
}
