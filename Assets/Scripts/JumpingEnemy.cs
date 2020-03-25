/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpingEnemy : MonoBehaviour
{
    public int health;
    public Rigidbody2D rb;
    public bool facingRight;
    public float speed;
    public float jumpForce;
    public bool isGrounded;
    public LayerMask isGroundLayer;
    public Transform groundCheck;
    public float groundCheckRadius;
    Animator anim;
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

        if(jumpForce <= 0)
        {
            jumpForce = 3.0f;
        }

        if (!groundCheck)
        {
            Debug.LogError("GroundCheck not found on " + name);
        }

        if (groundCheckRadius <= 0)
        {
            groundCheckRadius = 0.2f;
            Debug.LogWarning("GroundCheckRadius not set on " + name + ". Defaulting to " + groundCheckRadius);
        }

        anim = GetComponent<Animator>();

        if (!anim)
        {
            Debug.LogError("Animator not found on " + name);
        }

        rb = GetComponent<Rigidbody2D>();
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

        isGrounded = Physics2D.OverlapCircle(groundCheck.position,
            groundCheckRadius, isGroundLayer);
        anim.SetBool("grounded", isGrounded);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            // Prints a message to Console (Shortcut: Control+Shift+C)
            Debug.Log("Jump");

            // Zeros out force before applying a new force
            // - If force is not zeroed out, the force of gravity will have an effect on the jump
            // - Not setting velocity to 0
            //   - Gravity is -9.8 and force up would be 5 causing a force of -4.8 to be applied
            // - Setting velocity to 0
            //   - Gravity is reset to and force up would be 5 causing a force of 5.0 to be applied
            rb.velocity = Vector2.zero;

            // Unit Vector shortcuts that can be used
            // - Vector2.up --> new Vector2(0,1);
            // - Vector2.down --> new Vector2(0,-1);
            // - Vector2.right --> new Vector2(1,0);
            // - Vector2.left --> new Vector2(-1,0);

            // Applies a force in the UP direction
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }

        float moveValue = Input.GetAxisRaw("Horizontal");

        rb.velocity = new Vector2(moveValue * speed, rb.velocity.y);

        // Tells Animator to transition to another Clip
        // - Parameter must be created in Animator window under Parameter tab
        anim.SetFloat("speed", Mathf.Abs(moveValue));
        anim.SetBool("grounded", isGrounded);

        //Flipping the animation.
        if ((moveValue < 0 && !facingRight) || (moveValue > 0 && facingRight))
        {
            flip();
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
        if (collision.gameObject.tag == "EnemyObstacleBarrier")
        {
            flip();
        }
    }
}*/
