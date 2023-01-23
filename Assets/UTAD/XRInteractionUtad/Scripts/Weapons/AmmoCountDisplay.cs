using TMPro;
using UnityEngine;

namespace Utad.XRInteractionUtad.Scripts
{
	public class AmmoCountDisplay : MonoBehaviour
	{
		[SerializeField] private Weapon _weapon;
		[SerializeField] private TextMeshProUGUI _text;

		private void Update()
		{
			if (_weapon.Magazine == null)
			{
				_text.text = "0";
				return;
			}
			_text.text = _weapon.Magazine.RemainingRounds.ToString();
		}
	}
}