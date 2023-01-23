using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class TwoHandInteractable : XRGrabInteractable
{
    private IXRInteractor _primaryGrip;
    private IXRInteractor _secondaryGrip;

    // Something has entered: are this interactor selectable? Need to be checked.
    public override bool IsSelectableBy(IXRSelectInteractor interactor)
    {
        // for instance: if an interactor is done with the right hand, if another one comes, check that this new one
        // does not come from the right hand (must be the left hand).
        var isAlreadyGrabbed = firstInteractorSelecting != null && !interactor.Equals(firstInteractorSelecting);
        return base.IsSelectableBy(interactor) && !isAlreadyGrabbed;
    }

    // With the other hand, we need to pick up all the event's information entry.
    public void OnSecondHandGrab(SelectEnterEventArgs args)
    {
        Debug.Log("Secondary grip grabbed");
        _secondaryGrip = args.interactorObject;
    }

    public void OnSecondHandRelease(SelectExitEventArgs args)
    {
        Debug.Log("Secondary grip released");
        _secondaryGrip = null;
    }

    // This is the primary grip, the one that we have beeen working before with the pistol.
    protected override void OnSelectEntered(SelectEnterEventArgs args)
    {
        Debug.Log("Primary grip grabbed");
        _primaryGrip = args.interactorObject;
        base.OnSelectEntered(args);
    }

    // The gun has been released, so both grips must be null.
    protected override void OnSelectExited(SelectExitEventArgs args)
    {
        Debug.Log("Primary grip released");
        base.OnSelectExited(args);
        _secondaryGrip = null;
        _primaryGrip = null;
    }

    // note: this is another callback as OnSelecEntered or OnSelectExited and works by the time it is been interacting
    // with the object.
    public override void ProcessInteractable(XRInteractionUpdateOrder.UpdatePhase updatePhase)
    {
        if (_primaryGrip != null && _secondaryGrip != null)
        {
            var primaryPosition = _primaryGrip.transform.position;
            var secondaryPosition = _secondaryGrip.transform.position;
            _primaryGrip.transform.rotation = Quaternion.LookRotation(secondaryPosition - primaryPosition);
        }
        base.ProcessInteractable(updatePhase);
    }
}