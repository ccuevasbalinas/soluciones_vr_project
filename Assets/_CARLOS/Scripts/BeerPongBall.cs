using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class BeerPongBall : MonoBehaviour
{
    [SerializeField] private bool _isPlayerBall = false;
    [SerializeField] private float _launchSpeed = 10.0f;
    [SerializeField] private Transform _ballSpawn;
    [SerializeField] private LayerMask _targetLayer;
    [SerializeField] private LayerMask _floorLayer;

    [SerializeField] private ScriptableEvent _endOfTurnEvent;
    [SerializeField] private ScriptableEvent _enterPlayerCupEvent;
    [SerializeField] private ScriptableEvent _enterRivalCupEvent;

    private Transform _transform;
    private Rigidbody _rigidbody;

    private void Awake()
    {
        _transform = GetComponent<Transform>();
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        Invoke("EndOfTurn", 30); 
    }

    public void EndOfTurn()
    {
        _endOfTurnEvent.Raise();
    }

    private void OnTriggerEnter(Collider other)
    {
        // Ball triggers cup
        if (_targetLayer == (1 << other.gameObject.layer | _targetLayer))
        {
            if(_isPlayerBall)
            {
                Debug.Log("PELOTA ENTRA EN CUP DEL RIVAL");
                _enterRivalCupEvent.Raise();
            }
            else
            {
                Debug.Log("PELOTA ENTRA EN CUP DEL JUGADOR");
                _enterPlayerCupEvent.Raise();
            }
            other.gameObject.transform.parent.gameObject.SetActive(false);
            EndOfTurn();
           
        }
        // Ball triggers floor
        if (_floorLayer == (1 << other.gameObject.layer | _floorLayer))
        {
            Debug.Log("PELOTA TOCA EL SUELO");
            EndOfTurn();
        }
    }

    public void ResetBall()
    {
        _rigidbody.velocity = Vector3.zero;
        _rigidbody.angularVelocity = Vector3.zero;
        _transform.position = _ballSpawn.position;
    }

    public void ParabolicLaunch()
    {
        var angle = Random.Range(30.0f, 60.0f) * Mathf.Deg2Rad;

        var direction = _transform.forward;
        direction.y = Mathf.Tan(angle);
        direction = direction.normalized;

        //var direction = new Vector3(Mathf.Cos(angle), Mathf.Sin(angle), 0.0f);

        _rigidbody.velocity = direction * _launchSpeed;
    }

}
