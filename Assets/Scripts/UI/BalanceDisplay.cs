using Player;
using UnityEngine;
using UnityEngine.UI;

namespace UI {
	[RequireComponent(typeof(Text))]
	public class BalanceDisplay : MonoBehaviour
	{
		[SerializeField] private PlayerBalance playerBalance;
		private Text _text;

		private void Awake()
		{
			_text = GetComponent<Text>();
		}

		private void Update()
		{
			_text.text = $"Balance: {playerBalance.GetBalance()/100f:c2}";
		}
	}
}
