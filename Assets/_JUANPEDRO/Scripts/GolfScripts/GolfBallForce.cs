using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolfBallForce : MonoBehaviour
{
    [SerializeField]
    private Rigidbody golfBallRb;
    [SerializeField]
    private float golfBallForce;

    void Start()
    {
        golfBallRb = gameObject.GetComponent<Rigidbody>();
        golfBallRb.velocity = Vector3.zero;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("GolfIron"))
        {
            golfBallRb.AddForce(transform.right * golfBallForce, ForceMode.Impulse);
        }
    }
}
