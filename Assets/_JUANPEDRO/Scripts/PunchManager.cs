using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PunchManager : MonoBehaviour
{
    public int punchCount = 0;
    [SerializeField]
    private GameObject challengeUI;


    private void OnCollisionEnter(Collision collision)
    {
        if (challengeUI.activeSelf == true)
        {
            if (collision.gameObject.CompareTag("PunchGlove"))
            {
                punchCount++;
            }
        }
        else
        {
            this.enabled = true;
        }
    }
}
