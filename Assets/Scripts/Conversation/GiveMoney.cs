using Player;
using UnityEngine;
using UnityEngine.UI;

namespace Conversation {
	[CreateAssetMenu(fileName = "Give Money", menuName = "Conversation/Give Money", order = 1)]
	public class GiveMoney : ConversationElement
	{
		[SerializeField] private string speaker;
		[SerializeField] private int minAmount;
		[SerializeField] private int maxAmount;
		public override GameObject Display(Transform parent)
		{
			var amountToGive = Random.Range(minAmount, maxAmount);
			FindObjectOfType<PlayerBalance>().balance += amountToGive;
			
			var prefab = base.Display(parent);
			var textComponent = prefab.GetComponent<Text>();

			textComponent.text = $"- {speaker} gave you {amountToGive / 100f:c2} -";
			
			return prefab;
		}
	}
}
