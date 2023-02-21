using UnityEngine;

namespace Utad.XRInteractionUtad.Scripts
{
	[CreateAssetMenu(fileName = "NewMagazineType", menuName = "New Magazine Type", order = 0)]
	public class MagazineType : ScriptableObject
	{
		[field:SerializeField] public string Name { get; private set; }
		[field:SerializeField] public int Rounds { get; private set; }
	}
}