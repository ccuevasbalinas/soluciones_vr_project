using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WInCanvasVisible : MonoBehaviour
{
    [SerializeField] GameObject winCanvas;
    // Update is called once per frame
    void Update()
    {
        if (!gameObject.activeSelf)
        {
            winCanvas.SetActive(true);
        }   
    }
}
