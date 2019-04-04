using System.Collections.Generic;
using Conversation;
using UnityEngine;
using UnityEngine.UI;

namespace UI {
	public class ConversationManager : MonoBehaviour
	{
		[SerializeField] private ConversationObject targetConversation;
		[SerializeField] private Transform conversationContainer;
		[SerializeField] private int elementIndex;
		private string _textToRead = "";
		private Text _targetText;

		private void Start()
		{
			EndConversation();
		}

		public void StartConversation(ConversationObject conversation)
		{
			targetConversation = conversation;
			conversationContainer.gameObject.SetActive(true);
		}
		
		private void EndConversation()
		{
			conversationContainer.gameObject.SetActive(false);
			targetConversation = null;
			elementIndex = 0;
			
			// Delete all container elements.
			var children = new List<GameObject>();
			foreach (Transform child in conversationContainer) children.Add(child.gameObject);
			children.ForEach(Destroy);
		}

		public void ReadOut(string textToRead, Text textContainer)
		{
			_textToRead = textToRead;
			_targetText = textContainer;
		}

		public void Progress(ConversationObject conversation)
		{
			// Reset the conversation if it's different.
			if (conversation != targetConversation)
			{
				EndConversation();
			} 
			
			if (elementIndex == 0)
			{
				StartConversation(conversation);
				conversation.GetElements()[elementIndex].Display(conversationContainer);
				elementIndex++;
			}
			else if (elementIndex == conversation.GetElements().Length)
			{
				EndConversation();
			}
			else
			{
				conversation.GetElements()[elementIndex].Display(conversationContainer);
				elementIndex++;
			}
		}
		
		private void Update()
		{
			// Read out the text if there is any.
			if (_textToRead.Length > 0)
			{
				// Append the first character of the text to read out to the text display.
				_targetText.text += _textToRead[0];
				// Remove the first character.
				_textToRead = _textToRead.Substring(1, _textToRead.Length - 1);
			}
		}
	}
}
