using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ArcheryGameManager : MonoBehaviour
{
    public static int targetcount =0;
    public TimerScript timerCounter;
    [SerializeField] private string sceneToTeleport; 
    // Update is called once per frame
    void Update()
    {
        if(targetcount >= 10)
        {
            timerCounter.TimerOn = false;
        }    
    }
    void TeleportToMainscene()
    {
        if(timerCounter.TimerOn == false) {
            StartCoroutine(teleportCoroutine());
        }
    }
    IEnumerator teleportCoroutine()
    {
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene(sceneToTeleport);
    }
}
