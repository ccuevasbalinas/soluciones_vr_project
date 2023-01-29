using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class BeerPongGameManager : MonoBehaviour
{
    [SerializeField] private GameObject _playerBall;
    [SerializeField] private Transform _playerBallSpawn;
    [SerializeField] private List<GameObject> _playerCups;
    [SerializeField] private List<GameObject> _cupsSockets;

    private int _placedCups;
    private int _cupsToPlace;


    private void Awake()
    {
        _placedCups = 0;
        _cupsToPlace = _playerCups.Count;
        _playerBall.SetActive(false);
    }

    public void PlaceCup()
    {
        _placedCups = _placedCups + 1;
        if(_placedCups == _cupsToPlace) 
        {
            StartCoroutine(PrepareCupsForGame());
            RespawnBall();
            ActivateBeerPongBall();
        }
    }

    public void ActivateBeerPongBall()
    {
        _playerBall.SetActive(true);
    }

    public void RespawnBall() 
    {
        _playerBall.GetComponent<Transform>().position = _playerBallSpawn.position; 
    }


    public void DeactivateObjectGrab(GameObject gameObject)
    {
        gameObject.GetComponent<XRGrabInteractable>().enabled = false;
    }

    public void ActivateObjectGrab(GameObject gameObject) 
    {
        gameObject.GetComponent<XRGrabInteractable>().enabled=true;
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
            DeactivateObjectGrab(cup);
        }
    }

}
