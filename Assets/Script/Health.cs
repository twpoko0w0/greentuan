using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float hitPoints = 100f;
    public float currentHitPoints;
    public GameObject destroyFX;
    public GameObject destroyFXDrone;
    public AudioClip fireFXSound;
    // Start is called before the first frame update
    void Start()
    {
        currentHitPoints = hitPoints;
        
    }

    public void TakeDamage(float amt)
    {
        currentHitPoints -= amt;

        if(currentHitPoints <= 0)
        {
            currentHitPoints = 0;
            Die();
        }
    }

    // Update is called once per frame
    void Die()
    {
        if(gameObject.tag == "Enemy")
        {
            //eff enemy
            SoundScript.PlaySound("Expl");
            Instantiate(destroyFXDrone, this.transform.position, this.transform.rotation);
            Destroy(gameObject);
            Score.scoreValue += 20;
            

        }
        if (gameObject.tag == "Prop")
        {
            //eff prop
            Instantiate(destroyFX, this.transform.position, this.transform.rotation);
            Destroy(gameObject);
            Score.scoreValue += 5;
            SoundScript.PlaySound("Expl");
        }
        
    }
}
