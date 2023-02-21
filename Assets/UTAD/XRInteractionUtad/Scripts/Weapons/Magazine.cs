using UnityEngine;
using UnityEngine.Events;

namespace Utad.XRInteractionUtad.Scripts
{
	public class Magazine : MonoBehaviour, IMagazine
	{
		[field:SerializeField] public MagazineType MagazineType { get; private set; }
		[field:SerializeField] public UnityEvent OnMagazineEmpty { get; private set; }
		public int RemainingRounds { get; private set; }

		private void Awake()
		{
			RemainingRounds = MagazineType.Rounds;
		}

		public bool UseRound()
		{
			if (RemainingRounds <= 0) return false;
			RemainingRounds--;
			Debug.Log($"Round used, {RemainingRounds} remaining");
			if (RemainingRounds <= 0) OnMagazineEmpty.Invoke();
			return true;
		}
	}
}