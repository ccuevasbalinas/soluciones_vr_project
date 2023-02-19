using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarCounter : MonoBehaviour
{
    // Update is called once per frame
    public void StarCount()
    {
        ClimbingGameManager.starcount += 1;       
    }
}
