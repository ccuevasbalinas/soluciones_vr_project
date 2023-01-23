using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
public class MagSocketInteractor : XRSocketInteractor
{
    [SerializeField] private MagazineType[] _acceptedMagazine;
    [SerializeField] private Weapon _weapon;

    private IMagazine _incomingMagazine;


    protected override void Awake()
    {
        allowSelect = false;                // En el contexto de los Sockets, Select significa entrar en el socket. Luego, el interactor no permite que permita que entre nada.
        base.Awake();
    }

    // Cada vez que me entra algo en el Hover, identificamos el interactor, el interactuable y su información.
    protected override void OnHoverEntering(HoverEnteringEventArgs args)
    {
        // De estos argumentos que me han entrado, quiero el transform del interactableObject y ver si está el componente IMagainze. Si no lo hay...es que tu no eres para mí.
        _incomingMagazine = args.interactableObject.transform.GetComponent<IMagazine>();
        var validMagazine = _incomingMagazine != null && _acceptedMagazine.Contains(_incomingMagazine);
        if (validMagazine) { allowSelect = true; }
        base.OnHoverEntering(args);
    }

    protected override void OnSelectEntered(SelectEnterEventArgs args)
    {
        // de tu interactableObject, cogeme los colliders y apágamelos en el momento en que, por ejeplo, el cargador está ya metido en la pistola.
        foreach (var interactableObjectCollider in args.interactableObject.colliders)
            interactableObjectCollider.enabled = false;

        _weapon.LoadMagazine(_incomingMagazine);
        // _isMagazineLoaded = true;
        base.OnSelectEntered(args);
    }

    protected override void OnSelectExited(SelectExitEventArgs args)
    {
        // ahora vamos a hacer exactaente lo mismo que cuando se entraba en el Select, pero al contrario y le dotamos a los gameobjects de 'vida' otra vez.
        foreach (var interactableObjectCollider in args.interactableObject.colliders)
            interactableObjectCollider.enabled = true;

        _weapon.UnloadMagazine(_incomingMagazine);
        // _isMagazineLoaded = false;
        base.OnSelectExited(args);
    }

    // Cada vez que me sale algo en el Hover, identificamos el interactor, el interactuable y su información.
    protected override void OnHoverExited(HoverExitEventArgs args)
    {
        // De estos argumentos que me han entrado, quiero el transform del interactableObject y ver si está el componente IMagainze. Si no lo hay...es que tu no eres para mí.
        _incomingMagazine = args.interactableObject.transform.GetComponent<IMagazine>();
        var validMagazine = _incomingMagazine != null && _acceptedMagazine.Contains(_incomingMagazine);
        if (validMagazine) { allowSelect = false; }
        base.OnHoverExited(args);
    }
}
*/
