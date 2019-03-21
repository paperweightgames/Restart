using UnityEngine;

namespace Conversation {
	[CreateAssetMenu(fileName = "Speech", menuName = "Conversation/Speech", order = 1)]
	public class Speech : ConversationElement
	{
		[SerializeField] private string speaker;
		[SerializeField, TextArea(3, 10)] private string speech;
	}
}
