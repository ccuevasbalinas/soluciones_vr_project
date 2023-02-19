using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ClimbingGameManager : MonoBehaviour
{
    public static int starcount = 0;
    [SerializeField] private TimerScript timerCounter;
    [SerializeField] private string sceneToTeleport;
    // Update is called once per frame
    void Update()
    {
        if (starcount >= 10)
        {
            timerCounter.TimerOn = false;
        }
    }
    void TeleportToMainscene()
    {
        if (timerCounter.TimerOn == false)
        {
            StartCoroutine(teleportCoroutine());
        }
    }
    IEnumerator teleportCoroutine()
    {
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene(sceneToTeleport);
    }
}
