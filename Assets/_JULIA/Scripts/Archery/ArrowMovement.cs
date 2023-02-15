using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowMovement : MonoBehaviour
{
    [SerializeField]private GameObject arrow;
    private float speed = 2f;
   
    // Update is called once per frame
    void Update()
    {
        if (arrow.activeInHierarchy)
        {
            arrow.transform.position -= new Vector3(speed * Time.deltaTime, 0, 0);
        }
    }
}
