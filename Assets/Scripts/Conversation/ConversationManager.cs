using UnityEngine;

namespace Conversation {
	public class ConversationManager : MonoBehaviour
	{
		[SerializeField] private ConversationObject targetConversation;
		[SerializeField] private GameObject conversationContainer;
		[SerializeField] private int elementIndex;

		private void Awake()
		{
			// Clear the conversation at the start of the game.
			End();
		}

		public void StartConversation(ConversationObject conversation)
		{
			targetConversation = conversation;
			elementIndex = 0;
			conversationContainer.SetActive(true);
			DisplayElement();
		}

		public void End()
		{
			targetConversation = null;
			conversationContainer.SetActive(false);
		}

		public void Next()
		{
			elementIndex++;
			DisplayElement();
		}

		private void DisplayElement()
		{
			targetConversation.GetElement(elementIndex).Display(conversationContainer.transform);
		}
	}
}
