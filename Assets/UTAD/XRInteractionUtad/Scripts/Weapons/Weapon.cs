using UnityEngine;

namespace Utad.XRInteractionUtad.Scripts
{
	public class Weapon : MonoBehaviour
	{
		public IMagazine Magazine { get; private set; }
		
		public void LoadMagazine(IMagazine magazine)
		{
			Magazine = magazine;
			Debug.Log($"{Magazine.MagazineType.name} loaded on {name} with {Magazine.RemainingRounds} rounds");
		}

		public void UnloadMagazine()
		{
			Magazine = null;
		}

		public void Fire()
		{
			if (Magazine == null)
			{
				Debug.Log("I need a magazine");
				return;
			}
			if (Magazine.UseRound())
			{
				Debug.Log("FIRE");
			}
			else
			{
				Debug.Log("Out of ammo");
			}
		}
	}
}