using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipAnimation : MonoBehaviour { 
    public bool isFacingLeft;

    // Start is called before the first frame update
    void Start()
    {
}
    void flip()
    {
        isFacingLeft = !isFacingLeft;
        Vector3 scaleFactor = transform.localScale;
        scaleFactor.x *= -1;
        // or can use scaleFactor.x = -scaleFactor.x;
        transform.localScale = scaleFactor;
    }

    // Update is called once per frame
    void Update()
    {
    //if ((isFacingLeft && moveValue > 0) ||
    //(!isFacingLeft && moveValue < 0))
    //{
    //    flip();
    //}

}
}
