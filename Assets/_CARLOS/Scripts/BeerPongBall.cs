using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class BeerPongBall : MonoBehaviour
{
    public bool isPlayerBall;

    private Transform _transform;

    private Rigidbody _rigidbody;

    [SerializeField] private Transform _ballSpawn;

    [SerializeField] private LayerMask _targetLayer;
    [SerializeField] private LayerMask _floorLayer;

    [SerializeField] private ScriptableEvent _OnEnterCupEvent;
    

    private void Awake()
    {
        _transform = GetComponent<Transform>();
        _rigidbody = GetComponent<Rigidbody>(); 
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        // Ball triggers cup
        if (_targetLayer == (1 << other.gameObject.layer | _targetLayer))
        {
            Debug.Log("PELOTA ENTRA EN CUP");
            other.gameObject.transform.parent.gameObject.SetActive(false);
            ResetBall();
            _OnEnterCupEvent.Raise();
        }
        // Ball triggers floor
        if (_floorLayer == (1 << other.gameObject.layer | _floorLayer))
        {
            Debug.Log("PELOTA TOCA EL SUELO");
            ResetBall();
        }
    }

    public void ResetBall()
    {
        _rigidbody.velocity = Vector3.zero;
        _rigidbody.angularVelocity = Vector3.zero;
        _transform.position = _ballSpawn.position;
    }

}
