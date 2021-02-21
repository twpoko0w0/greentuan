using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserProjectile : MonoBehaviour
{
    public float speed = 2f;
    public int damage = 25;

    private Transform thisTransform;
    public Transform laserHitFXPreab;
    // Start is called before the first frame update
    void Start()
    {
        thisTransform = transform;
        
    }

    // Update is called once per frame
    void Update()
    {
        thisTransform.position += Time.deltaTime * speed * thisTransform.forward;


        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.SendMessage("TakeDamage", damage, SendMessageOptions.DontRequireReceiver);

            ContactPoint contact = collision.contacts[0];
            Quaternion rot = Quaternion.FromToRotation(Vector3.up, contact.normal);
            Vector3 pos = contact.point;
            Instantiate(laserHitFXPreab, pos, rot);
            Destroy(gameObject);
        }

        if (collision.gameObject.tag == "Prop")
        {
            collision.gameObject.SendMessage("TakeDamage", damage, SendMessageOptions.DontRequireReceiver);

            ContactPoint contact = collision.contacts[0];
            Quaternion rot = Quaternion.FromToRotation(Vector3.up, contact.normal);
            Vector3 pos = contact.point;
            Instantiate(laserHitFXPreab, pos, rot);
            Destroy(gameObject);
        }
        if (collision.gameObject.tag == "DeadStar")
        {
            ContactPoint contact = collision.contacts[0];
            Quaternion rot = Quaternion.FromToRotation(Vector3.up, contact.normal);
            Vector3 pos = contact.point;
            Instantiate(laserHitFXPreab, pos, rot);
            
        }
    }
}
