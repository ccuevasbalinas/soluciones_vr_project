using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhatPieceIsInside : MonoBehaviour
{
    private bool cross;
    
    private void OnTriggerEnter(Collider other)
    {
        /*
        //comprueba la etiqueta que tiene el collider que entra dentro
        if (other.CompareTag("X"))
        {
            Debug.Log("Cruz");
            cross = true;
        }
        if (other.CompareTag("O"))
        {
            Debug.Log("Circulo");
            cross = false;
        }*/
    }
}
