using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.XR.Interaction.Toolkit;

public class BeerPongGameManager : MonoBehaviour
{
    [SerializeField] private GameObject _playerBall;
    [SerializeField] private List<GameObject> _playerCups;
    [SerializeField] private List<GameObject> _cupsSockets;

    private int _placedCups;
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

    public void TakeOffPlayerCup()
    {
        _remainPlayerCups = _remainPlayerCups - 1;
        if(AllPlayerCupsOut())
        {
            Debug.Log("Gana Rival");
        }
    }

    public void TakeOffRivalCup()
    {
        _remainRivalCups = _remainRivalCups - 1;
        if(AllRivalCupsOut()) 
        {
            Debug.Log("Gana Jugador");
        }
    }

    public void Test()
    {
        Debug.Log("Hola");
    }

}
