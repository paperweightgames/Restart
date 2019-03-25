using UnityEngine;

namespace Conversation {
	[CreateAssetMenu(fileName = "Conversation", menuName = "Conversation/Conversation", order = 1)]
	public class ConversationObject : ScriptableObject
	{
		[SerializeField] private ConversationElement[] conversationElements;

		public ConversationElement GetElement(int index)
		{
			return conversationElements[index];
		}
	}
}
