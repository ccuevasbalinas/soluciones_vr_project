using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class BowStringController : MonoBehaviour
{
    [SerializeField] private BowString bowStringRenderer; //cuerda del arco 
    private XRGrabInteractable interactable;
    [SerializeField] Transform midPointGrabObject, midPointVisualObject, midPointParent;
    private Transform interactor;
    [SerializeField] private float bowStringStrechLimit = 0.3f;

    private void Awake(){
        interactable = midPointGrabObject.GetComponent<XRGrabInteractable>();
    }

    private void Start(){
        interactable.selectEntered.AddListener(PrepareBowString);
        interactable.selectExited.AddListener(ResetBowString);
    }

    private void ResetBowString(SelectExitEventArgs arg0)
    {
        //vuelve al centro cuando se suelta
        interactor = null;
        midPointGrabObject.localPosition = Vector3.zero;//posicion local cero corresponde a la posicion inicial en el centro de la cuerda
        midPointVisualObject.localPosition = Vector3.zero;
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

            //convierte la posicion del punto medio de la cuerda a posicion local del midPointGrabObject
            //la posicion de la mano se convierte en la posicion local del midPointGrabObject
            Vector3 midPointLocalSpace = midPointParent.InverseTransformPoint(midPointGrabObject.position);
            //offset en valor absoluto de separación de la cuerda en el eje z
            float midPointLocalAbsolute = Math.Abs(midPointLocalSpace.z);
            //crea la cuerda de acuerdo al movimiento del midPointGrabObject
            bowStringRenderer.CreateString(midPointGrabObject.transform.position);
        }

    }
}
