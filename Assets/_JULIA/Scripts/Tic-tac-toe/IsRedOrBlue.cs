using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class IsRedOrBlue : MonoBehaviour
{
    private bool _isRed;
    private GameObject go;

    private void OnTriggerEnter(Collider other)
    {
        if (go.GetComponent<Material>().color == Color.red)
        {
            _isRed = true;
            Debug.Log("is Red");
        }
        else
        {
            _isRed = false;
            Debug.Log("is Blue");
        }
    }
}
