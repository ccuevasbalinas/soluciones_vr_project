using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class SocketChecking : MonoBehaviour
{
    #region Variables
    #region Variables · Public Variable
    public ScriptableEvent onPiecePlacedCorrectly;              // Reference to a scriptable event for placing a piece correctly.
    #endregion

    #region Variables · Private Variables
    [SerializeField] private string tagPiece;                   // Tag that 'real' pieces of the canvas has.
    private  XRSocketInteractor _socket;
    private int _socketId;
    private bool _checkingPiece;
    #endregion
    #endregion

    #region Methods
    void Start()
    {
        _socket = GetComponent<XRSocketInteractor>();
        _socketId = int.Parse(transform.name.Split(' ')[1]);
        _checkingPiece = false;
    }

    void Update()
    {
        socketCheck();
    }
    
    // Function used for says: "okey, a new piece wants to be placed in the canvas. Can we put this piece on it?"
    public void piecedPlaced()
    {
        _checkingPiece = true;
    }

    // Function that checks if a puzzle's piece has been placed correctly.
    public void socketCheck()
    {
        // A new piece is trying to be placed in the canvas. Let's check if it can or not..
        if (_checkingPiece)
        {
            // Has the socket received a piece to be placed in the canvas? 
            if ( _socket.GetOldestInteractableSelected() != null)
            {
                // If so, is the piece that is trying to be placed in the socket from the canvas a correct piece from the real picture?
                // (note: remember that there's more pieces that do not belong to the figure. Just to make the game more difficult.)
                IXRSelectInteractable objName = _socket.GetOldestInteractableSelected();
                if (objName.transform.tag == tagPiece)
                {
                    // If so, does this piece has been placed? (Because if so, get out of this IF block.)
                    int pieceId = int.Parse(objName.transform.name.Split(' ')[1]);
                    if(!PicassoGameManager.idPiecesPlaced.Contains(pieceId))
                    {
                        // If not, does the player placed the piece in its real position?
                        if (pieceId == _socketId)
                        {
                            // If so, activate the event for placing the piece correcly and desactivate the game object in order not to be 
                            // grabbed anymore because it has been placed right.
                            PicassoGameManager.idPiecePlacedCorrectly = pieceId;
                            onPiecePlacedCorrectly.Raise();
                        }
                    }
                }    
            }

            // Once we have chck if the piececan be placed in the canvas or not, let's give the oportunity to another one.
            _checkingPiece = false;
        }    
    }
    #endregion
}