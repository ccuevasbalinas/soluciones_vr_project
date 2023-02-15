using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nextBoard : MonoBehaviour
{
    [SerializeField]
    private Transform firstB, secondB, thirdB, fourthB, fifthB, canvasBoardTwo, canvasBoardThree, canvasBoardFour, canvasBoardFive;
    [SerializeField]
    private GameObject canvasBoardOne;
    [SerializeField]
    private GameObject nextBoardButton;
    public int index = 1;
    public bool isFinished = false;


    public void onClick()
    {
        switch (index)
        {
            case 1:
                canvasBoardOne.transform.position = canvasBoardTwo.position;
                canvasBoardOne.transform.rotation = canvasBoardTwo.rotation;
                firstB.position = secondB.position;

                nextBoardButton.SetActive(false);
                index = 2;
                break;
            case 2:
                canvasBoardOne.transform.position = canvasBoardThree.position;
                canvasBoardOne.transform.rotation = canvasBoardThree.rotation;
                firstB.position = thirdB.position;

                nextBoardButton.SetActive(false);
                index = 3;
                break;
            case 3:
                canvasBoardOne.transform.position = canvasBoardFour.position;
                canvasBoardOne.transform.rotation = canvasBoardFour.rotation;
                firstB.position = fourthB.position;

                nextBoardButton.SetActive(false);
                index = 4;
                break;
            case 4:
                canvasBoardOne.transform.position = canvasBoardFive.position;
                canvasBoardOne.transform.rotation = canvasBoardFive.rotation;
                firstB.position = fifthB.position;

                nextBoardButton.SetActive(false);
                index = 5;
                break;
            case 5:
                isFinished = true;
                break;
            default:
                break;
        }
    }
}
