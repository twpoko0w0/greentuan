using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public GameObject Drone;
    private int xPos;
    private int zPos;
    private int yPos;
    public int cubeCount;
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
            Debug.Log("SpawnBitch!");

            xPos = Random.Range(-700,2000 );
            zPos = Random.Range(-1200, 1700);
            yPos = Random.Range(-400, 700);
            Instantiate(Drone, new Vector3(xPos, yPos, zPos), Quaternion.identity);
            yield return new WaitForSeconds(4f);
            //Invoke("cubeCount += 1", 10f);
            cubeCount += 1;


        }
    }
}
