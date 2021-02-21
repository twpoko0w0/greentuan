using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerShooting : MonoBehaviour
{

    public float coolDown = 0f;
    public float fireRate = 0f;

    public bool isFiring = false;

    public Transform leftFirePoint;
    public Transform rightFirePoint;

    public GameObject laserPrefab;

    public AudioClip fireFXSound;


    // Start is called before the first frame update
    void Start()
    {
        isFiring = false;
        

    }

    // Update is called once per frame
    void Update()
    {
        CheckInput();
        coolDown -= Time.deltaTime;

        if (isFiring == true)
        {
            
            Fire();
        }
        
    }
    void CheckInput()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            isFiring = true;
        }
        else
        {
            isFiring = false;
        }
    }
    void Fire()
    {

        if(coolDown > 0)
        {
            return;    // หยุดยิง
        }
        if(fireFXSound != null)
        {
            // ถ้ามีไฟล์เสียงให้เล่นเสียงนี้
            //AudioSource.PlayClipAtPoint(fireFXSound, transform.position, 1f);
            

            

        }
        StartCoroutine(coroutineA());

        IEnumerator coroutineA()
        {

            GameObject.Instantiate(laserPrefab, leftFirePoint.position, leftFirePoint.rotation);
            SoundScript.PlaySound("fire");
            yield return new WaitForSeconds(0.1f);
            SoundScript.PlaySound("fire");
            GameObject.Instantiate(laserPrefab, rightFirePoint.position, rightFirePoint.rotation);



        }

        coolDown = fireRate;
    }
}
