using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthrPlayer : MonoBehaviour
{
    public float hitPoints = 100f;
    public float currentHitPoints;
    public GameObject destroyFX;
    public AudioClip playerAuioDeath;

    public GameObject gameOverText;

    public GameObject menuButton;
    public GameObject playButton;

    // Start is called before the first frame update
    void Start()
        {
        Time.timeScale = 1;
        currentHitPoints = hitPoints;
        gameOverText.gameObject.SetActive(false);

        menuButton.SetActive(false);
        playButton.SetActive(false);

    }
    void Update()
    {
        if (currentHitPoints <= 0)
        {
            AudioSource.PlayClipAtPoint(playerAuioDeath, transform.position);   
            Instantiate(destroyFX, this.transform.position, this.transform.rotation);
            SoundScript.PlaySound("Expl");
            gameObject.SetActive(false);
            Debug.Log("Player Death!");

            //ขึ้น button
            menuButton.SetActive(true);
            playButton.SetActive(true);

            //ขึ้น text Over
            gameOverText.gameObject.SetActive(true);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            currentHitPoints -= 20;   
            Debug.Log("HP -20");
            //Instantiate(destroyFX, transform.position, Quaternion.identity);

        }

        if (collision.gameObject.tag == "Prop")
        {
            currentHitPoints -= 10;
            Debug.Log("HP -10");
            //Instantiate(destroyFX, transform.position, Quaternion.identity);

        }

        if (collision.gameObject.tag == "DeadStar")
        {
            currentHitPoints -= 100;
            Debug.Log("HP -100");
            //Instantiate(destroyFX, transform.position, Quaternion.identity);

        }
    }
}
