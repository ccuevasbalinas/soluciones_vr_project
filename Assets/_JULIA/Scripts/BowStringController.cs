using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR.Interaction.Toolkit;

public class BowStringController : MonoBehaviour
{
    [SerializeField] private BowString bowStringRenderer; //cuerda del arco 
    private XRGrabInteractable interactable;
    [SerializeField] private Transform midPointGrabObject;
    private Transform interactor;

    private void Awake(){
        interactable = midPointGrabObject.GetComponent<XRGrabInteractable>();
    }

    private void Start(){
        interactable.selectEntered.AddListener(PrepareBowString);
        interactable.selectExited.AddListener(ResetBowString);
    }

    private void ResetBowString(SelectExitEventArgs hand)
    {
        //vuelve al centro cuando se suelta
        interactor = null;
        midPointGrabObject.localPosition = Vector3.zero;//posicion local cero corresponde a la posicion inicial en el centro de la cuerda
        bowStringRenderer.CreateString(null);//recrear la cuerda recta
    }

    private void PrepareBowString(SelectEnterEventArgs hand)
    {
        //sigue la mano cuando se agarra
        interactor = hand.interactorObject.transform;//referencia al transform de la mano
    }

    private void Update()
    {
        if(interactor != null){

            //crea la cuerda de acuerdo al movimiento del midPointGrabObject
            bowStringRenderer.CreateString(midPointGrabObject.transform.position);
        }

    }
}
