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
    private PunchManager punchBoxing;

    [SerializeField]
    private TextMeshProUGUI punchPoints;

    private void Update()
    {
        if (punchBoxing.enabled && PresentationUI.activeSelf == true)
        {
            PresentationUI.SetActive(false);
            InstructionsUI.SetActive(true);

            StartCoroutine(ActivateUI());
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

        yield return new WaitForSeconds(120);
        ChallengeUI.SetActive(false);
        timerChallenge.enabled = false;

        SummaryUI.SetActive(true);
        punchPoints.text = string.Format("{0:00}", punchBoxing.punchCount);

    }

}
