using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject item1;
    public GameObject item2;


    float Collectible;
    // Start is called before the first frame update
    void Start()
    {
        Collectible = Random.Range(0, 2);

        if (Collectible < 1)
            Instantiate(item1, transform.position, Quaternion.identity);
        else if (Collectible >= 1)
            Instantiate(item2, transform.position, Quaternion.identity);
    }


    // Update is called once per frame
    void Update()
    {

    }
    /*randomCollectible = Random.Range(1, 5);
    Debug.Log(randomCollectible);

    switch (randomCollectible)
    {
        case 1:
            Instantiate(prefab1, transform.position, Quaternion.identity);
            break;
        case 2:
            Instantiate(prefab2, transform.position, Quaternion.identity);
            break;
        case 3:
            Instantiate(prefab3, transform.position, Quaternion.identity);
            break;
        case 4:
            Instantiate(prefab4, transform.position, Quaternion.identity);
            break;

    }*/


}