using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetPingPong : MonoBehaviour
{
    float t;
    private Vector3 pos1;
    private Vector3 pos2;
    private float speed = 0.2f;
    private void Start()
    {
        pos1 = transform.position - new Vector3(0, 0.25f, 0);
        pos2 = transform.position + new Vector3(0, 0.25f, 0);
    }

    void Update()
    {
        t += 1f * Time.deltaTime;

        //transform.position = new Vector3(transform.position.x, Mathf.PingPong(Time.time * 0.2f, 1f), transform.position.z);
        transform.position = Vector3.Lerp(pos1, pos2, Mathf.PingPong(Time.time * speed, 0.5f));
    }
}
