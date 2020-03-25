using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Class to control 'Character' GameObject
// - Must be attached to Character in Hierarchy
// - Handles 'Character' mechanics
// - Filename must match class name below
public class Character : MonoBehaviour
{

    //Projectile!!!
    public Transform projectileSpawnPoint;
    public Projectile projectilePrefab;
    public float projectileForce;

    //audiostuff
    public AudioSource aSource;

    public AudioClip Flame_Ball_SFX;
    public AudioClip Jumping_SFX;
    public AudioClip MM_Shoot;
    public AudioClip Pausing_SFX;
    public AudioClip Bow_SFX;
    public AudioClip awesomeness;
    

    private Level currentLevel;



    // Method 1: Keeps a reference Rigidbody2D through script
    // - Not shown in Inspector
    Rigidbody2D rb;

    // Method 2: Keeps a reference Rigidbody2D through script
    // - Shown in Inspector
    public Rigidbody2D rb2;

    // Handles movement speed of Character
    // - Can be adjusted through Inspector while in Play mode
    // - Used to debug movements and test the 'speed' of the Character
    public float speed;

    // Handles jump speed of Character

    // How high Character jumps
    public float jumpForce;

    private float jumpBonus = 5.0f;
    private float jumpBonusDuration = 3.0f;

    // Is 'Character' on ground
    // - Are they able to jump
    // - Must be grounded to jump (aka no double jump)
    public bool isGrounded;

    // What is the Ground? 
    // - Player can only jump on GameObjects that are on "Ground" layer  
    public LayerMask isGroundLayer;

    // Tells script where to check if 'Characer' is on ground
    public Transform groundCheck;

    // Size of overlapping circle being checked against ground Colliders
    public float groundCheckRadius;

    public bool isFacingLeft = false;

    // Handles animation states for Character
    // - Idle, Run, Attack...etc.
    Animator anim;

    public int health;
    // public int lives;


    // Use this for initialization
    void Start()
    {

        //Projectile
        if (!projectileSpawnPoint)
            Debug.LogError("Missing projectileSpawn");

        if (!projectilePrefab)
            Debug.LogError("Missing projectilePrefab");

        if (projectileForce <= 0)
        {
            projectileForce = 7.0f;
            Debug.Log("projectileForce was not set." +
            " Defaulting to " + projectileForce);
        }

        // Method 1: Save a reference of Component in script
        // - Component must be added in Inspector
        rb = GetComponent<Rigidbody2D>();

        // Check if Component exists
        if (!rb) // or if(rb == null)
        {
            // Prints a message to Console (Shortcut: Control+Shift+C)
            Debug.LogError("Rigidbody2D not found on " + name);
        }

        // Method 1: Save a reference of Component in script
        // - Component must be added in Inspector
        // - Component should be dragged into variable in Script through Inspector
        if (!rb2)
        {
            // Prints a message to Console (Shortcut: Control+Shift+C)
            Debug.LogError("Rigidbody2D not found on " + name);
        }

        // Check if variable is set to something not 0
        if (speed <= 0)
        {
            // Set a default value to variable if not set in Inspector
            speed = 5.0f;

            // Prints a message to Console (Shortcut: Control+Shift+C)
            Debug.LogWarning("Speed not set on " + name + ". Defaulting to " + speed);
        }

        // Check if variable is set to something not 0
        if (jumpForce <= 0)
        {
            // Set a default value to variable if not set in Inspector
            jumpForce = 5.0f;

            // Prints a message to Console (Shortcut: Control+Shift+C)
            Debug.LogWarning("JumpForce not set on " + name + ". Defaulting to " + jumpForce);
        }

        // Check if variable is set to something
        if (!groundCheck)
        {
            // Prints a message to Console (Shortcut: Control+Shift+C)
            Debug.LogError("GroundCheck not found on " + name);
        }

        // Check if variable is set to something not 0
        if (groundCheckRadius <= 0)
        {
            // Set a default value to variable if not set in Inspector
            groundCheckRadius = 0.2f;

            // Prints a message to Console (Shortcut: Control+Shift+C)
            Debug.LogWarning("GroundCheckRadius not set on " + name + ". Defaulting to " + groundCheckRadius);
        }

        // Save a reference of Component in script
        // - Component must be added in Inspector
        anim = GetComponent<Animator>();

        // Check if Component exists
        if (!anim)
        {
            // Prints a message to Console (Shortcut: Control+Shift+C)
            Debug.LogError("Animator not found on " + name);
        }
        currentLevel = GameObject.Find("Level1").GetComponent<Level>();

        // Check if variable is set to something
        if (!aSource)
        {
            // Add an 'AudioSource' because it is not added
            aSource = gameObject.AddComponent<AudioSource>();

            // Change variables on the 'AudioSource'
            aSource.loop = false;
            aSource.playOnAwake = false;

        }
    }



    // Update is called once per frame
    void Update()
    {

        // Checks if Left (or a) or Right (or d) is pressed
        // - "Horizontal" must exist in Input Manager (Edit-->Project Settings-->Input)
        // - Returns -1(left), 1(right), 0(nothing)
        // - Use GetAxis for value -1-->0-->1 and all decimal places. (Gradual change in values)
        float moveValue = Input.GetAxisRaw("Horizontal");

        // Check if 'groundCheck' GameObject is touching a Collider on Ground Layer
        // - Can change 'groundCheckRadius' to a smaller value for better precision or if 'Character' is smaller or bigger
        isGrounded = Physics2D.OverlapCircle(groundCheck.position,
            groundCheckRadius, isGroundLayer);
        anim.SetBool("grounded", isGrounded);

        // Check if "Jump" button was pressed
        // - "Jump" must exist in Input Manager (Edit-->Project Settings-->Input)
        // - Configuration can be changed later
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            // Prints a message to Console (Shortcut: Control+Shift+C)
            Debug.Log("Jump");

            //Play jump audio clip when button is pressed
            SoundManager.instance.PlaySingleSound(Jumping_SFX, 1.0f);

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

        // Check if Left Control was pressed
        if (Input.GetButtonDown("Fire1"))
        //if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            anim.SetTrigger("Fire1");
            // Prints a message to Console (Shortcut: Control+Shift+C)
            if (Input.GetButtonDown("Fire1"))
            {
                Debug.Log("Pew pew");
                               
                fire();
            }
        }
        // Move Character using Rigidbody2D
        // - Uses moveValue from GetAxis to move left or right
        rb.velocity = new Vector2(moveValue * speed, rb.velocity.y);

        // Tells Animator to transition to another Clip
        // - Parameter must be created in Animator window under Parameter tab
        anim.SetFloat("speed", Mathf.Abs(moveValue));
        anim.SetBool("grounded", isGrounded);

        //Flipping the animation.
        if ((moveValue < 0 && !isFacingLeft) || (moveValue > 0 && isFacingLeft))
        {
            flip();
        }

        //Out of lives change to GameOver scene



    }


    public void fire()
    {
        Projectile p = Instantiate(projectilePrefab, projectileSpawnPoint.position, projectileSpawnPoint.rotation);
        if (isFacingLeft)
        {
            p.speed = -projectileForce;
        }
        else
        {
            p.speed = projectileForce;
        }
        print(SoundManager.instance);
        SoundManager.instance.PlaySingleSound(Flame_Ball_SFX, 2.0f);
    }

    void flip()
    {
        //flip the game object on the x axis
        Vector3 scaleFactor = transform.localScale;
        scaleFactor.x *= -1;
        transform.localScale = scaleFactor;

        //flip the boolean
        isFacingLeft = !isFacingLeft;
    }

    public void AddJumpBonus()
    {
        jumpForce += jumpBonus;
        StartCoroutine(ResetJumpPower());
    }

    IEnumerator ResetJumpPower()
    {
        yield return new WaitForSeconds(jumpBonusDuration);
        jumpForce -= jumpBonus;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        print(collision.gameObject.tag);
        if (collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "EnemyProjectile")
        {
            SoundManager.instance.PlaySingleSound(MM_Shoot);
            Destroy(collision.gameObject);
            health--;

            if (health <= 0 && lives > 0)
            {
                print("HERE");
                GameManager.instance.restart();
                SoundManager.instance.PlaySingleSound(MM_Shoot, 1.0f);
                --lives;
                Destroy(gameObject);
            }

            if (health <= 0 && lives <= 0)
            {
                --lives;
                SoundManager.instance.musicSource.clip = awesomeness;
                SoundManager.instance.musicSource.Play();
                GameManager.instance.endGame();
                Destroy(gameObject);
            }

        }
    }



    public int lives
    {
        get { return GameManager.instance.playerLives; }
        set
        {
            GameManager.instance.playerLives = value;

            for (int i = 0; i < currentLevel.livesDisplay.Length; i++)
            {
                currentLevel.livesDisplay[i].enabled = i < GameManager.instance.playerLives;
            }
            //number of images matches number of lives
            Debug.Log("Lives changed to " + GameManager.instance.playerLives);

        }
    }



}
