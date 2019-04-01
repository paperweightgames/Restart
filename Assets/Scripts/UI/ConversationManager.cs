using Conversation;
using UnityEngine;
using UnityEngine.UI;

namespace UI {
	public class ConversationManager : MonoBehaviour
	{
		[SerializeField] private ConversationObject targetConversation;
		[SerializeField] private GameObject conversationContainer;
		[SerializeField] private int elementIndex;
		private string _textToRead = "";
		private Text _targetText;

		public void StartConversation(ConversationObject conversation)
		{
			targetConversation = conversation;
			conversationContainer.SetActive(true);
			elementIndex = 0;
		}
		
		public void EndConversation()
		{
			conversationContainer.SetActive(false);
			targetConversation = null;
		}

		public void ReadOut(string textToRead, Text textContainer)
		{
			_textToRead = textToRead;
			_targetText = textContainer;
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
