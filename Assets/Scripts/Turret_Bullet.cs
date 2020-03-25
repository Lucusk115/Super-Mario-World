﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret_Bullet : MonoBehaviour
{
     float speed;
     float lifetime=3;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, lifetime);

        rb = GetComponent<Rigidbody2D>();
        if (transform.localRotation.y == 0)
        {
            speed = 5;
        }
        else
        {
            speed = -5;
        }

        rb.velocity = new Vector3(speed, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
