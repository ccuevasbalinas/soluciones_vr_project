using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimerScript : MonoBehaviour
{
    [SerializeField]
    private float TimeLeft;
    private bool TimerOn = false;
    private float initTime = 0;
    [SerializeField]
    private TextMeshProUGUI TimerText;
    [SerializeField]
    private float TimeMark = 0;


    void Start()
    {
        TimerOn = true;
        initTime = TimeLeft;
    }

    void Update()
    {
        if (TimerOn)
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
                //TimerOver.SetActive(true);
                //StartCoroutine(SceneManager(2));
            }


            if (TimeMark >= 40)
            {
                Debug.Log("Marca de tiempo alcanzada");
            }
            else
            {
                TimeMark += Time.deltaTime;
                Debug.Log(TimeMark);
            }
        }
    }

    void updateTimer(float currentTime)
    {
        if (initTime == 4)
        {
            TimerText.text = string.Format("{0:0}", currentTime);
        }
        else
        {
            currentTime += 1;
            float minutes = Mathf.FloorToInt(currentTime / 60);
            float seconds = Mathf.FloorToInt(currentTime % 60);

            TimerText.text = string.Format("{0:00} : {1:00}", minutes, seconds);
        }
    }


    //IEnumerator SceneManager(int seconds)
    //{
    //    yield return new WaitForSeconds(seconds);
    //    sceneManager.LoadScene("startMenu");

    //}
}
