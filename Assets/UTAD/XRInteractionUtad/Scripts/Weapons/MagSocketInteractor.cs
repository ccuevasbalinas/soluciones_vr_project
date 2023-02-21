using System.Linq;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

namespace Utad.XRInteractionUtad.Scripts
{
	public class MagSocketInteractor : XRSocketInteractor
	{
		[SerializeField] private MagazineType[] _acceptedMagazines;
		[SerializeField] private Weapon _weapon;

		private IMagazine _incomingMagazine;
		private Coroutine _selectionCancelCoroutine;
		private bool _isMagazineLoaded;

		protected override void Awake()
		{
			allowSelect = false;
			base.Awake();
		}
		
		protected override void OnHoverEntering(HoverEnterEventArgs args)
		{
			EnableMagazineSocketSelectionForValidMagazines(args);
			base.OnHoverEntering(args);
		}
		protected override void OnSelectEntered(SelectEnterEventArgs args)
		{
			DisableMagazineCollidersSoItCannotBePulledOutByHand(args);
			LoadWeaponWithIncomingMagazine();
			base.OnSelectEntered(args);
		}
		protected override void OnSelectExited(SelectExitEventArgs args)
		{
			EnableMagazineCollidersSoTheyCanBePickedUpInTheWorld(args);
			UnloadMagazineFromWeapon();
			DisableMagazineSocketSelection(args);
			base.OnSelectExited(args);
		}
		protected override void OnHoverExited(HoverExitEventArgs args)
		{
			DisableMagazineSocketSelection();
			base.OnHoverExited(args);
		}


		private void EnableMagazineSocketSelectionForValidMagazines(HoverEnterEventArgs args)
		{
			_incomingMagazine = args.interactableObject.transform.GetComponent<IMagazine>();
			var validMagazine = _incomingMagazine != null && _acceptedMagazines.Contains(_incomingMagazine.MagazineType);
			if (validMagazine)
			{
				allowSelect = true;
			}
		}

		private void LoadWeaponWithIncomingMagazine()
		{
			_weapon.LoadMagazine(_incomingMagazine);
			_isMagazineLoaded = true;
		}
		
		private void DisableMagazineSocketSelection(SelectExitEventArgs args)
		{
			allowSelect = false;
			args.interactableObject.transform.GetComponent<InteractionLayerChanger>().ChangeInteractionLayer(0);
		}

		private void UnloadMagazineFromWeapon()
		{
			_weapon.UnloadMagazine();
			_isMagazineLoaded = false;
		}

		private static void DisableMagazineCollidersSoItCannotBePulledOutByHand(SelectEnterEventArgs args)
		{
			foreach (var interactableObjectCollider in args.interactableObject.colliders)
			{
				interactableObjectCollider.enabled = false;
			}
		}
		
		private static void EnableMagazineCollidersSoTheyCanBePickedUpInTheWorld(SelectExitEventArgs args)
		{
			foreach (var interactableObjectCollider in args.interactableObject.colliders)
			{
				interactableObjectCollider.enabled = true;
			}
		}
		
		private void DisableMagazineSocketSelection()
		{
			if (!_isMagazineLoaded) allowSelect = false;
		}
	}
}