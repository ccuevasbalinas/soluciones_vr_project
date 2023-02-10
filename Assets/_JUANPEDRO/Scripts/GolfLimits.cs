using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolfLimits : MonoBehaviour
{
    [SerializeField]
    private GameObject golfInitPos;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("restart"))
        {
            transform.position = golfInitPos.transform.position;
        }
        else if (collision.gameObject.CompareTag("win"))
        {
            //Aqui habría que sacar algún UI por pantalla para indicar que ha terminado
            Debug.Log("YOU WIN");
        }
    }
}
