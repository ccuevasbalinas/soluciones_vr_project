using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetDisappear : MonoBehaviour
{
    [SerializeField] AudioSource arrowImpact;
    private void OnTriggerEnter(Collider other)
    {
        arrowImpact.Play();
        gameObject.SetActive(false);
        ArcheryGameManager.targetcount += 1;
    }
}
