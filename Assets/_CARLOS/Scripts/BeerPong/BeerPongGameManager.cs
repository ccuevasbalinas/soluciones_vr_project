using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.XR.Interaction.Toolkit;

public class BeerPongGameManager : MonoBehaviour
{
    private int _placedCups = 0;
    private int _beerPongCups;
    private int _remainPlayerCups;
    private int _remainRivalCups;

    private bool _turnOfPlayer = true;
    private bool _endOfGame = false;

    [SerializeField] private GameObject _playerBall;
    [SerializeField] private GameObject _rivalBall;

    [SerializeField] private List<GameObject> _playerCups;
    [SerializeField] private List<GameObject> _playerCupsSockets;

    [SerializeField] private ScriptableEvent StartBeerPongGameEvent;
    [SerializeField] private ScriptableEvent EndBeerPongGameEvent;

    private void Awake()
    {
        _beerPongCups = _remainPlayerCups = _remainRivalCups = 6;
    }

    public void PlaceCup()
    {
        _placedCups = _placedCups + 1;
        if(_placedCups == _beerPongCups) 
        {
            Debug.Log("Todas los vasos colocados");
            StartCoroutine(WaitTimeCoroutine(2));
            foreach (GameObject cupSocket in _playerCupsSockets)
            {
                cupSocket.SetActive(false);
            }
            foreach (GameObject cup in _playerCups)
            {
                cup.GetComponent<XRGrabInteractable>().enabled = false;
                cup.GetComponent<Rigidbody>().isKinematic = true;
            }
            StartCoroutine(WaitTimeCoroutine(2));
            StartBeerPongGameEvent.Raise();
        }
    }

    public void TakeOffPlayerCup()
    {
        _remainPlayerCups = _remainPlayerCups - 1;
        if (_remainPlayerCups == 0)
        {
            Debug.Log("Pierde el jugador");
            _endOfGame = true;
        }
    }

    public void TakeOffRivalCup()
    {
        _remainRivalCups = _remainRivalCups - 1;
        if (_remainRivalCups == 0)
        {
            Debug.Log("Gana el jugador");
            _endOfGame = true;
        }
    }

    public void HandleTurn()
    {
        StartCoroutine(WaitTimeCoroutine(5));
        if(!_endOfGame)
        {
            if (_turnOfPlayer)
            {
                
                TurnOfPlayer();
            }
            else
            {
                StartCoroutine(WaitTimeCoroutine(3));
                
                TurnOfRival();
            }
        }
        else
        {
            EndBeerPongGameEvent.Raise();
        }

    }

    public void DeactivateCurrentBall()
    {
        if(_turnOfPlayer)
        {
            _rivalBall.SetActive(false);
        }
        else
        {
            _playerBall.SetActive(false);
        }
    }

    public void SwitchTurn()
    {
        if (_turnOfPlayer == true)
        {
            _turnOfPlayer = false;
        }
        else
        {
            _turnOfPlayer = true;
        }
    }

    public void TurnOfPlayer()
    {
        if (!_endOfGame)
        {
            StartCoroutine(WaitTimeCoroutine(2));
            Debug.Log("Turno del jugador");
            _playerBall.SetActive(true);
            _playerBall.GetComponent<BeerPongBall>().ResetBall();
        }
        else
        {
            EndBeerPongGameEvent.Raise();
        }
    }

    public void TurnOfRival()
    {
        if (!_endOfGame)
        {
            StartCoroutine(WaitTimeCoroutine(3));
            Debug.Log("Turno del rival");
            _rivalBall.SetActive(true);
            var rivalBall = _rivalBall.GetComponent<BeerPongBall>();
            rivalBall.ResetBall();
            StartCoroutine(WaitTimeCoroutine(2));
            rivalBall.ParabolicLaunch();
        }
        else
        {
            EndBeerPongGameEvent.Raise();
        }
    }

    private IEnumerator WaitTimeCoroutine(float time)
    {
        yield return new WaitForSeconds(time);
    }
}
