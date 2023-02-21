using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimerScript : MonoBehaviour
{
    [SerializeField]
    private float TimeLeft;
    public bool TimerOn = false;
    private float initTime = 0;
    [SerializeField]
    private TextMeshProUGUI TimerText;
    [SerializeField]
    private TextMeshProUGUI bestTimeText;
    [SerializeField]
    public float TimeMark;
    private float TimeUp;
    public bool Countdown = false;
    public static float bestTime = 999999;


    void Start()
    {
        TimerOn = true;
        initTime = TimeLeft;
        TimeUp = TimeMark;
    }

    void Update()
    {
        if (TimerOn)
        {
            if (Countdown == true)
            {
                if (TimeLeft > 0)
                {
                    TimeLeft -= Time.deltaTime;
                    updateTimer(TimeLeft);
                }
                else
                {
                    TimeLeft = 0;
                    TimerOn = false;

                    TimerText.transform.parent.gameObject.SetActive(false);
                }
            }
            else
            {
                TimeMark += Time.deltaTime;
                updateTimer(TimeMark);           
            }
        }
        else
        {
            if (bestTimeText)
            {
                if(TimeMark < bestTime)
                {
                    bestTime = TimeMark;
                    bestTime += 1;
                    float minutes = Mathf.FloorToInt(bestTime / 60);
                    float seconds = Mathf.FloorToInt(bestTime % 60);

                    bestTimeText.text = string.Format("{0:00} : {1:00}", minutes, seconds);
                }
            }
        }
    }

    void updateTimer(float currentTime)
    {
        if (initTime == 4)
        {
            TimerText.text = string.Format("{0:0}", currentTime);
        }
        else if(initTime == 120 || TimeUp == 0)
        {
            currentTime += 1;
            float minutes = Mathf.FloorToInt(currentTime / 60);
            float seconds = Mathf.FloorToInt(currentTime % 60);

            TimerText.text = string.Format("{0:00} : {1:00}", minutes, seconds);

        }
    }
}
