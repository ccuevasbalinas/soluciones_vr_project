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
            gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
        }
        else if (collision.gameObject.CompareTag("win"))
        {
            transform.position = golfInitPos.transform.position;
        }
    }
}
