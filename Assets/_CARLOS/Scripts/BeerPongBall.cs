using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeerPongBall : MonoBehaviour
{
    [SerializeField] private LayerMask _targetLayer;
    //[SerializeField] private LayerMask _resetLayer;

    private void OnTriggerEnter(Collider other)
    {
        // Ball triggers cup
        if (_targetLayer == (1 << other.gameObject.layer | _targetLayer))
        {
            Debug.Log("PELOTA ENTRA EN CUP");
        }
        /*
        // Ball triggers floor
        if (_resetLayer == (1 << other.gameObject.layer | _resetLayer))
        {
        }
        */
        // Case 1: Player's ball enters Rival's  cup
        // Case 2: Rival's  ball enters Player's cup
    }

}
