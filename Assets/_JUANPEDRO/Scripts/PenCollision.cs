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
            Debug.Log("Tiempo minínimo alcanzado.");
            //Por aqui vamos a tener que poner una forma de que el jugador vea un UI que le muestre la opción de pasar al siguiente board
            //ademas de teletransportarlo a la posición correcta si pulsa el botón, etc.
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
