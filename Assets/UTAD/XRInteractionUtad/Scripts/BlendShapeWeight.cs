using UnityEngine;

namespace Utad.XRInteractionUtad.Scripts
{
	public class BlendShapeWeight : MonoBehaviour
	{
		[SerializeField] private SkinnedMeshRenderer _meshRenderer;
		[SerializeField] private int _index;

		public void SetBlendShapeWeight(float value)
		{
			_meshRenderer.SetBlendShapeWeight(_index, value);
		}
	}
}