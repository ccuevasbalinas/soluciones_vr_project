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

    [SerializeField] private ScriptableEvent StartBeerPongGameEvent;
    [SerializeField] private ScriptableEvent EndBeerPongGameEvent;

    private void Awake()
    {
        _beerPongCups = _remainPlayerCups = _remainRivalCups = 6;
    }

    // Game Preparation
    public void PlaceCup()
    {
        _placedCups = _placedCups + 1;
        if(_placedCups == _beerPongCups) 
        {
            Debug.Log("Todas los vasos colocados");
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
        if(!_endOfGame)
        {
            if (_turnOfPlayer)
            {
                Debug.Log("Turno del jugador");
                TurnOfPlayer();
            }
            else
            {
                Debug.Log("Turno del rival");
                TurnOfRival();
            }
        }
        else
        {
            EndBeerPongGameEvent.Raise();
        }

    }

    public void SwitchTurn()
    {
        _turnOfPlayer = !_turnOfPlayer;
    }

    public void TurnOfPlayer()
    {
        _playerBall.SetActive(true);
        _playerBall.GetComponent<BeerPongBall>().ResetBall();
    }

    public void TurnOfRival()
    {
        _rivalBall.SetActive(true);
        var rivalBall = _rivalBall.GetComponent<BeerPongBall>();
        rivalBall.ResetBall();
        StartCoroutine(WaitTimeCoroutine(1.5f));
        rivalBall.ParabolicLaunch();
    }

    private IEnumerator WaitTimeCoroutine(float time)
    {
        yield return new WaitForSeconds(time);
    }

    /*
    [SerializeField] private GameObject _playerBall;
    [SerializeField] private List<GameObject> _playerCups;
    [SerializeField] private List<GameObject> _cupsSockets;

    private int _cupsToPlace;

    private int _remainPlayerCups;
    private int _remainRivalCups;

    private void Awake()
    {
        _placedCups = 0;
        _cupsToPlace = _remainPlayerCups = _remainRivalCups= _playerCups.Count;
        _playerBall.SetActive(false);
    }

    public void PlaceCup()
    {
        _placedCups = _placedCups + 1;
        if(_placedCups == _cupsToPlace) 
        {
            StartCoroutine(PrepareCupsForGame());
            _playerBall.SetActive(true);
        }
    }

    private IEnumerator PrepareCupsForGame()
    {
        yield return new WaitForSeconds(2);
        foreach (GameObject cupSocket in _cupsSockets)
        {
            cupSocket.SetActive(false);
        }
        foreach (GameObject cup in _playerCups)
        {
            cup.GetComponent<XRGrabInteractable>().enabled = false;
            cup.GetComponent<Rigidbody>().isKinematic = true;
        }
    }

    public bool AllPlayerCupsOut()
    {
        return _remainPlayerCups == 0;
    }

    public bool AllRivalCupsOut()
    {
        return _remainRivalCups == 0;
    }



    public void Test()
    {
        Debug.Log("Hola");
    }
    */
}
