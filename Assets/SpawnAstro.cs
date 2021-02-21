using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnAstro : MonoBehaviour
{
    public GameObject Astro;
    private int xPos;
    private int zPos;
    private int yPos;
    private int cubeCount = 0;
    public int clone;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(CubeSp());
    }

    // Update is called once per frame

    IEnumerator CubeSp()
    {
        while (cubeCount < clone)
        {
            Debug.Log("SpawnAstro");

            xPos = Random.Range(-3000, 400);
            zPos = Random.Range(1000, -2000);
            yPos = Random.Range(-1200, 2400);
            Instantiate(Astro, new Vector3(xPos, yPos, zPos), Quaternion.identity);
            yield return new WaitForSeconds(10f);
            //Invoke("cubeCount += 1", 10f);
            cubeCount += 1;


        }
    }
}
