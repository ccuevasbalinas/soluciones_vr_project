using System;
using UnityEngine.Events;

namespace Utad.XRInteractionUtad.Scripts
{
	public interface IMagazine
	{
		MagazineType MagazineType { get; }
		int RemainingRounds { get; }
		bool UseRound();
		UnityEvent OnMagazineEmpty { get; }
	}
}