using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestWalkEnemy : MonoBehaviour
{

    public int health;
    public Rigidbody2D rb;
    public bool facingRight;
    public float speed;

    public AudioSource aSource;
    public AudioClip MM_Shoot;
    // Start is called before the first frame update
    void Start()
    {
        if (health <= 0)
        {
            health = 5;
        }

        if (speed == 0)
        {
            speed = 2;
        }

        rb = GetComponent<Rigidbody2D>();
        aSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (facingRight)
        {
            rb.velocity = new Vector2(speed, 0);
        
        }
        else
        {
            rb.velocity = new Vector2(-speed, 0);
        }
    }

    void flip()
    {
        facingRight = !facingRight;

        //flip the game object on the x axis
        Vector3 scaleFactor = transform.localScale;
        scaleFactor.x *= -1;
        transform.localScale = scaleFactor;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Projectile")
        {
            health--;
            if (health <= 0)
            {


                print("projectile problem");
                aSource.Play(); 
                Destroy(gameObject);
            }
        }
        else if (collision.gameObject.tag != "Ground")
        {
            flip();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "EnemyObstacleBarrier")
        {
            flip();
        }
    }
}
