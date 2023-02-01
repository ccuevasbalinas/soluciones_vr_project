using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class SocketChecking : MonoBehaviour
{
    private  XRSocketInteractor _socket;
    private int _socketIndex;

    // Start is called before the first frame update
    void Start()
    {
        _socket = GetComponent<XRSocketInteractor>();
        _socketIndex = int.Parse(transform.name.Split(' ')[2]);
    }

    void Update()
    {
        //socketCheck();
    }

    public void socketCheck()
    {
       if ( _socket.GetOldestInteractableSelected() != null)
       {
            IXRSelectInteractable objName = _socket.GetOldestInteractableSelected();
            int indexPiece = int.Parse(objName.transform.name.Split(' ')[1]);

            if (indexPiece == _socketIndex)
                Debug.Log(indexPiece + " in socket of " + _socketIndex);
       }
        
    }
}
