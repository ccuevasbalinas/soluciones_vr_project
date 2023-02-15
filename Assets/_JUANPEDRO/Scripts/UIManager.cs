using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private TimerScript timerStart, timerChallenge;

    [SerializeField]
    private GameObject PresentationUI, InstructionsUI, StartingUI, ChallengeUI, SummaryUI;

    [SerializeField]
    private HitsManager hitObjective;

    [SerializeField]
    private TextMeshProUGUI hitPoints;

    [SerializeField]
    private nextBoard nextBoard;

    [SerializeField]
    private TimerScript timeBlackBoard;

    public bool blackBoardGame = false;

    private void Update()
    {
        if (hitObjective.start == true && PresentationUI.activeSelf == true)
        {
            PresentationUI.SetActive(false);
            InstructionsUI.SetActive(true);

            StartCoroutine(ActivateUI());
        }

        if (nextBoard.isFinished == true)
        {
            nextBoard.isFinished = false;

            timeBlackBoard.TimerOn = false;

            ChallengeUI.SetActive(false);
            timerChallenge.enabled = false;
            SummaryUI.SetActive(true);

            timeBlackBoard.TimeMark += 1;
            float minutes = Mathf.FloorToInt(timeBlackBoard.TimeMark / 60);
            float seconds = Mathf.FloorToInt(timeBlackBoard.TimeMark % 60);

            hitPoints.text = string.Format("{0:00} : {1:00}", minutes, seconds);
        }
    }

    IEnumerator ActivateUI()
    {
        yield return new WaitForSeconds(5);
        InstructionsUI.SetActive(false);
        StartingUI.SetActive(true);
        timerStart.enabled = true;

        yield return new WaitForSeconds(4);
        StartingUI.SetActive(false);
        timerStart.enabled = false;

        ChallengeUI.SetActive(true);
        timerChallenge.enabled = true;
        
        if (blackBoardGame == false)
        {
            yield return new WaitForSeconds(120);
            ChallengeUI.SetActive(false);
            timerChallenge.enabled = false;

            SummaryUI.SetActive(true);
            hitPoints.text = string.Format("{0:00}", hitObjective.pointsCount);
        }
    }

}
