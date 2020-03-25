using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallBuilder : MonoBehaviour
{

    public GameObject myCubePrefab;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 10; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                //Instantiate(myCubePrefab, new Vector3(i, j, 0), Quaternion.identity);
               /* GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
                cube.transform.position = new Vector3(i, j, 0);
                cube.AddComponent<Rigidbody>();
                cube.AddComponent<BoxCollider>();*/
            }
        } 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
