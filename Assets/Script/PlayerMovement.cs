using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Transform target;
    public Vector3 distance = new Vector3(0f, 1.6f, -20.2f);

    public float positionDamping = 2.0f;
    public float rotateDamping = 2.0f;

    private Transform thisTransform;
    // Start is called before the first frame update
    void Start()
    {
        thisTransform = transform;
        
    }

    // Update is called once per frame
    void Update()
    {
        if(target == null)
        {
            return;
        }

        Vector3 wantedPosition = target.position + (target.rotation * distance);
        Vector3 currentPosition = Vector3.Lerp(thisTransform.position, wantedPosition, positionDamping * Time.deltaTime);

        thisTransform.position = currentPosition;

        Quaternion wantedRotation = Quaternion.LookRotation(target.position - thisTransform.position, target.up);

        thisTransform.rotation = wantedRotation;
        
    }
}

// player ที่ชื่อ traget และกำหนด position และ roration ให้ตาม target โดยความ smooth จะใช้คำสั่ง vector3.Lerp 
