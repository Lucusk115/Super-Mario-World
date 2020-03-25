using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawn : MonoBehaviour
{
    public GameObject prefab1;
    public GameObject prefab2;
    public GameObject prefab3;
    public GameObject prefab4;
    public GameObject prefab5;

    int randomCollectible;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        randomCollectible = Random.Range(1, 5);
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

        }
    }
}
