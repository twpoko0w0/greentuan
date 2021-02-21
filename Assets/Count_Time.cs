using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Count_Time : MonoBehaviour
{
    float currentTime = 0f;
    public float startingTime;
    public GameObject gameWinText;

    //Game object ที่จะทำให้หายไปช่วงที่เวลาหมด
    public GameObject PlayTimeOut;

    public GameObject menuButton;
    public GameObject playButton;

    [SerializeField] Text countdownText;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        gameWinText.gameObject.SetActive(false);
        currentTime = startingTime;

        //button 
        menuButton.SetActive(false);
        playButton.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        currentTime -= 1 * Time.deltaTime;
        countdownText.text = currentTime.ToString("0");

        if (currentTime <= 0)
        {

            currentTime = 0;

            //ขึ้น button
            menuButton.SetActive(true);
            playButton.SetActive(true);

            //ขึ้น text Win
            gameWinText.gameObject.SetActive(true);
            Time.timeScale = 0;

            //Destroy(PlayTimeOut);
            //Destroy(Enemy);
            //gameObject.SetActive(false);

            //PlayTimeOut.SetActive(false);
        }
    }
}
