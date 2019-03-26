using Conversation;
using UnityEngine;
using UnityEngine.UI;

namespace UI {
	public class ConversationManager : MonoBehaviour
	{
		[SerializeField] private ConversationObject targetConversation;
		[SerializeField] private GameObject conversationContainer;
		[SerializeField] private int elementIndex;
		private string _textToReadOut = "";
		private Text _targetText;

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

		public void ReadOut(string textToReadOut, Text targetText)
		{
			_textToReadOut = textToReadOut;
			_targetText = targetText;
		}

		private void Update()
		{
			print(_textToReadOut);
			if (_textToReadOut.Length > 0)
			{
				_targetText.text += _textToReadOut[0];
				_textToReadOut = _textToReadOut.Substring(1, _textToReadOut.Length - 1);
			}
		}
	}
}
