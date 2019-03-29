using Player;
using UnityEngine;

namespace Conversation {
	[CreateAssetMenu(fileName = "Begging", menuName = "Conversation/Begging", order = 1)]
	public class Begging : ConversationElement
	{
		[SerializeField] private int minAmount;
		[SerializeField] private int maxAmount;
		public override GameObject Display(Transform parent)
		{
			FindObjectOfType<PlayerBalance>().balance += minAmount;
			return null;
		}
	}
}
