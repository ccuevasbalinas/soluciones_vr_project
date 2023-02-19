using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPoint : MonoBehaviour
{
    [SerializeField] float startPointX;
    [SerializeField] float startPointZ;

    // Start is called before the first frame update
    void Start()
    {
        float xPoint = transform.position.x;
        xPoint = startPointX;
        float zPoint = transform.position.z;
        xPoint = startPointZ;
    }

}
