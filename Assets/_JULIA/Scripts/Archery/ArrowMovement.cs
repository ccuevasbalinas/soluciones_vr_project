using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowMovement : MonoBehaviour
{
    [SerializeField]private GameObject arrow;
    private float speed = 0.01f;
    [SerializeField] Transform attachPoint;
    [SerializeField] AudioSource arrowFlying;
   
    // Update is called once per frame
    void Update()
    {
        if (arrow.activeInHierarchy)
        {
            arrowFlying.Play();
            arrow.transform.position = attachPoint.position + new Vector3(speed * Time.deltaTime, 0, 0);
        }
    }
}
