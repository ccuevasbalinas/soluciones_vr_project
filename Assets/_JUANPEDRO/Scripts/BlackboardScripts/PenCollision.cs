using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PenCollision : MonoBehaviour
{
    [SerializeField]
    private float totalTime;
    [SerializeField]
    private GameObject nextBoardButton;
    [SerializeField]
    private GameObject finishBoardButton;
    public nextBoard nextBoard;

    private void Update()
    {
        if(totalTime >= 5)
        {
            if (nextBoard.index == 5)
            {
                finishBoardButton.SetActive(true);
                this.enabled = false;
            }
            else
            {
                nextBoardButton.SetActive(true);
                this.enabled = false;
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("BlackboardPen"))
        {
            totalTime += Time.deltaTime;
        }
    }



}
