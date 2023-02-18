using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClayPigeonShootingGameManager : MonoBehaviour
{

    public static bool roundActive = false;

    [SerializeField] private float _roundTime = 60.0f;
    
    [SerializeField] private ClayPigeonShootingDisparator _disparator1;
    [SerializeField] private ClayPigeonShootingDisparator _disparator2;

    [SerializeField] private ScriptableEvent EndOfRoundEvent;

    public void StartRound()
    {
        Debug.Log("EMPIEZA RONDA");
        roundActive= true;
        StartCoroutine(WaitTimeCoroutine(_roundTime));  
    }

    private IEnumerator WaitTimeCoroutine(float t)
    {
        yield return new WaitForSeconds(t);
        roundActive = false;
        Debug.Log("FINAL RONDA");
        EndOfRoundEvent.Raise();
    }
}
