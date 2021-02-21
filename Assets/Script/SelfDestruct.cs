using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestruct : MonoBehaviour
{

    public float selfDestructTime = 1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        selfDestructTime -= Time.deltaTime;
        if(selfDestructTime <= 0)
        {
            Destroy(gameObject);
        }


        


    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);

        }
        if (collision.gameObject.tag == "Prop")
        {
            Destroy(gameObject);

        }
        if (collision.gameObject.tag == "DeadStar")
        {
            Destroy(gameObject);

        }
    }
}
