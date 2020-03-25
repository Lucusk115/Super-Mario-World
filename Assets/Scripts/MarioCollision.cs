using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarioCollision : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        print("enter: " + Time.time);
    }
    private void OnCollisionStay(Collision collision)
    {
        print("stay: " + Time.time);
    }
    private void OnCollisionExit(Collision collision)
    {
        print("exit: " + Time.time);
    }
}
