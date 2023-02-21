using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

namespace Utad.XRInteractionUtad.Scripts
{
	public class MagEjector : MonoBehaviour
	{
		[SerializeField] private XRDirectInteractor _leftHand;
		[SerializeField] private XRDirectInteractor _rightHand;
		[SerializeField] private InputActionReference _leftMagRelease;
		[SerializeField] private InputActionReference _rightMagRelease;
		[SerializeField] private Animator _weaponAnimator;
		[SerializeField] private string _ejectMagTrigger;

		// Funcion que permite que cuando cojamos el arma 
		public void WeaponPickedUp(SelectEnterEventArgs args)
		{
			// si el interactor es la mano izquierda, coge la referencia del input de la mano izquierda y cuando la acción se haga, hazme la función de ejecucción de una bala.
			if ((XRDirectInteractor) args.interactorObject == _leftHand)
			{
				_leftMagRelease.action.performed += EjectMag;
			}

			// si el interactor es la mano derecha, coge la referencia del input de la mano derecha y cuando la acción se haga, hazme la función de ejecucción de una bala.
			else
			{
				_rightMagRelease.action.performed += EjectMag;
			}
		}

		// Función creada para quitar la subscripción a la función de ejecucción de una bala en el caso de que suelte el arma.
		public void WeaponReleased(SelectExitEventArgs args)
		{
			_leftMagRelease.action.performed -= EjectMag;
			_rightMagRelease.action.performed -= EjectMag;
		}

		// Función que asocia el trigger del animator al Magazine.
		public void EjectMag(InputAction.CallbackContext context)
		{
			_weaponAnimator.SetTrigger(_ejectMagTrigger);
		}
	}
}