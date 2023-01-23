using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

namespace Utad.XRInteractionUtad.Scripts
{
	public class InteractionLayerChanger : MonoBehaviour
	{
		[SerializeField] private XRGrabInteractable _interactable;
		[SerializeField] private InteractionLayerMask[] _interactionLayer;

		public void ChangeInteractionLayer(int index)
		{
			_interactable.interactionLayers = _interactionLayer[index];
		}
	}
}