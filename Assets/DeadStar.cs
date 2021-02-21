using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadStar : MonoBehaviour
{
    public float speed;

    Vector3 rotate = new Vector3(0, 0, 0);
    // Start is called before the first frame update
    void Start()
    {

        Vector3 newRotate = new Vector3(0, 0, 0);
        


    }

    // Update is called once per frame
    void Update()
    {
        rotate.y = speed;

        transform.Rotate(rotate);

    }
}
