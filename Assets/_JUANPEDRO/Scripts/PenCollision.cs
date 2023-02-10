using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PenCollision : MonoBehaviour
{
    [SerializeField]
    private float totalTime;

    private void Update()
    {
        if(totalTime == 30)
        {
            Debug.Log("Tiempo min�nimo alcanzado.");
            //Por aqui vamos a tener que poner una forma de que el jugador vea un UI que le muestre la opci�n de pasar al siguiente board
            //ademas de teletransportarlo a la posici�n correcta si pulsa el bot�n, etc.
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.layer == 3)
        {
            totalTime += Time.time;
        }
    }

}
