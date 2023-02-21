using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HitsManager : MonoBehaviour
{
    public int pointsCount = 0;
    [SerializeField]
    private GameObject challengeUI;
    public bool start = false;


    private void OnCollisionEnter(Collision collision)
    {
        if (challengeUI.activeSelf == true)
        {
            if (collision.gameObject.CompareTag("PunchGlove") || collision.gameObject.CompareTag("win"))
            {
                pointsCount++;
            }
        }
        else if(collision.gameObject.CompareTag("PunchGlove") || collision.gameObject.CompareTag("GolfIron"))
        {
            start = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("BlackboardPen"))
        {
            start = true;
        }
    }
}
