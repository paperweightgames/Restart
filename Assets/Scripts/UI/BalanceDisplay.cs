using Player;
using UnityEngine;
using UnityEngine.UI;

namespace UI {
	[RequireComponent(typeof(Text))]
	public class BalanceDisplay : MonoBehaviour
	{
		[SerializeField] private PlayerBalance _playerBalance;
		private Text _text;

		private void Awake()
		{
			_text = GetComponent<Text>();
		}

		private void Update()
		{
			_text.text = $"{_playerBalance.GetBalance() / 100f:c2}";
		}
	}
}
