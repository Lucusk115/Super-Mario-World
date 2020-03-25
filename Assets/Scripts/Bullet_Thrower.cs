using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Thrower : MonoBehaviour
{
    public float fireRate;
    public Rigidbody2D projectile;
    public Transform leftSpawnPoint;
    public Transform rightSpawnPoint;
    public bool shootLeft;
    public GameObject target = null;
    float timeSinceLastFire = 0;
    float distanceCheck;
    public float range;

    // Start is called before the first frame update
    void Start()
    {
        if (!target)
        {
            target = GameObject.FindWithTag("Player");
        }
    }

    // Update is called once per frame
    void Update()
    {
        distanceCheck = Vector2.Distance(transform.position, target.transform.position);
         if (distanceCheck <= range)
         {
             timeSinceLastFire += Time.deltaTime;
             if (timeSinceLastFire >= fireRate)
             {
                 timeSinceLastFire = 0;
                 fire();
             }
         }
    }
        void fire()
        {
            shootDirectionCheck();
            if (shootLeft)
            {
            print("left");
                Instantiate(projectile, leftSpawnPoint.position, leftSpawnPoint.rotation);
                //Instantiate(projectile, leftSpawnPoint);
            }
            else
        {
            print("right");
            Instantiate(projectile, rightSpawnPoint.position, rightSpawnPoint.rotation);
            }
        }
        void shootDirectionCheck()
        {
            if (target.transform.position.x < transform.position.x)
            {
                shootLeft = true;
            }
            else
            {
                shootLeft = false;
            }
        }
       /* private void OnTriggerStay2D(Collider2D collision)
        {   // Turret shoots when trigger area is entered.
            if (collision.gameObject.tag == "Player")
            {
                timeSinceLastFire += Time.deltaTime;
                if (timeSinceLastFire >= fireRate)
                {
                    timeSinceLastFire = 0;
                    fire();
                }
            }
        }*/
    
}