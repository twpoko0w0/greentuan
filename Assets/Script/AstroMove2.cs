using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AstroMove2 : MonoBehaviour
{
    public float acx;
    public float acy;
    public float acz;

    Vector3 currentposition = new Vector3(0, 0, 0);
    Vector3 rotate = new Vector3(0, 0, 0);

    float vex;
    float vey;
    float vez;

    private float movementDuration = 15f;
    private float waitBeforeMoving = 2f;
    private bool hasArrived = false;

    void Start()
    {
        rotate.x = Random.Range(-1.0f, 1.0f);
        rotate.x = Random.Range(-1.0f, 1.0f);
        rotate.x = Random.Range(-1.0f, 1.0f);










    }

    private void Update()
    {

        transform.Rotate(rotate);
        if (!hasArrived)
        {
            hasArrived = true;
            float randX = Random.Range(-1500.0f, 1500.0f);
            float randZ = Random.Range(-1500.0f, 1500.0f);
            float randy = Random.Range(-1500.0f, 1500.0f);
            StartCoroutine(MoveToPoint(new Vector3(randX, randy, randZ)));
        }
    }
    private IEnumerator MoveToPoint(Vector3 targetPos)
    {
        float timer = 0.0f;
        Vector3 startPos = transform.position;

        while (timer < movementDuration)
        {
            timer += Time.deltaTime;
            float t = timer / movementDuration;
            t = t * t * t * (t * (6f * t - 15f) + 10f);
            transform.position = Vector3.Lerp(startPos, targetPos, t);

            yield return null;
        }

        yield return new WaitForSeconds(waitBeforeMoving);
        hasArrived = false;
    }


    // Start is called before the first frame update


    // Update is called once per frame
}
