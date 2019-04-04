using Player;
using UnityEngine;

namespace Conversation {
	[CreateAssetMenu(fileName = "Give Money", menuName = "Conversation/Give Money", order = 1)]
	public class GiveMoney : ConversationElement
	{
		[SerializeField] private int minAmount;
		[SerializeField] private int maxAmount;
		public override GameObject Display(Transform parent)
		{
			var amountToGive = Random.Range(minAmount, maxAmount);
			FindObjectOfType<PlayerBalance>().balance += amountToGive;
			return null;
		}
	}
}
