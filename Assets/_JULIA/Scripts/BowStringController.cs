using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class BowStringController : MonoBehaviour
{
    [SerializeField] private BowString bowStringRenderer; //cuerda del arco 
    private XRGrabInteractable interactable;
    [SerializeField] private Transform midPointGrabObject;
    private Transform interactor;
    [SerializeField] private GameObject arrow;
    private SelectExitEventArgs hand;
    private float speed = 2f;
    private float time = 0;

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
        if(hand.interactorObject.isSelectActive == true) //si la mano coge la cuerda
        {
            arrow.SetActive(true); //se activa la visibilidad de la flecha cuando se agarra el arco
        }
    }

    private void Update()
    {
        if(interactor != null){

            //crea la cuerda de acuerdo al movimiento del midPointGrabObject
            bowStringRenderer.CreateString(midPointGrabObject.transform.position);
        }

        if (arrow.activeInHierarchy) //si la flecha está visible
        {

            //si x de la flecha es menor que el x del midPoint
            if(arrow.transform.position.x < midPointGrabObject.position.x)
            {
                time += 1;
                //la flecha se mueve
                arrow.transform.position -= new Vector3(speed * Time.deltaTime, 0, 0);
                /*if(time == 1)
                {
                    if(arrow.transform.SetParent != null)
                    {
                        arrow.transform.SetParent(null);
                    }
                }*/
            }
        }
    }
}
