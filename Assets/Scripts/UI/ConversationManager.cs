﻿using System.Collections.Generic;
using Conversation;
using Interaction;
using UnityEngine;
using UnityEngine.UI;

namespace UI {
	public class ConversationManager : MonoBehaviour
	{
		[SerializeField] private ConversationObject _targetConversation;
		[SerializeField] private Transform _conversationContainer;
		[SerializeField] private int _elementIndex;
		[SerializeField] private float _readOutSpeed;
		[SerializeField] private InteractionReceiver _interactionReceiver;
		private string _textToRead = "";
		private Text _targetText;
		private float _timeSinceRead;

		private void Start()
		{
			EndConversation();
		}

		public void StartConversation(ConversationObject conversation)
		{
			_targetConversation = conversation;
			_conversationContainer.gameObject.SetActive(true);
		}
		
		public void EndConversation()
		{
			/*
			// Remove the conversation from the stranger.
			if (_interactionReceiver.GetInteractions().Count > 0)
			{
				_interactionReceiver.RemoveInteraction(_interactionReceiver.GetInteractions()[0]);
			}
			*/
			
			ResetConversation();
			
			if (_interactionReceiver.GetInteractions().Count > 0)
			{
				_interactionReceiver.RemoveInteraction(_interactionReceiver.GetInteractions()[0]);
			}
			
			//_interactionReceiver.GetInteractions()[0].SetEnded(true);
		}

		public void ResetConversation()
		{
			_conversationContainer.gameObject.SetActive(false);
			_targetConversation = null;
			_elementIndex = 0;
			_textToRead = "";
			
			// Delete all container elements.
			var children = new List<GameObject>();
			foreach (Transform child in _conversationContainer) children.Add(child.gameObject);
			children.ForEach(Destroy);
		}

		public void ReadOut(string textToRead, Text textContainer)
		{
			// Set the new message if there is no text to read.
			if (_textToRead != "")
			{
				_targetText.text += _textToRead;
			}
			_textToRead = textToRead;
			_targetText = textContainer;
		}

		public void Progress(ConversationObject conversation)
		{
			// Reset the conversation if it's different.
			if (conversation != _targetConversation)
			{
				ResetConversation();
			} 
			// Start a new conversation.
			if (_elementIndex == 0)
			{
				StartConversation(conversation);
				conversation.GetElements()[_elementIndex].Display(_conversationContainer);
				_elementIndex++;
			}
			// End the conversation.
			else if (_elementIndex == conversation.GetElements().Length)
			{
				EndConversation();
			}
			// Progress otherwise.
			else
			{
				conversation.GetElements()[_elementIndex].Display(_conversationContainer);
				_elementIndex++;
			}
		}
		
		private void Update()
		{
			_timeSinceRead += Time.deltaTime;
			_timeSinceRead = Mathf.Clamp(_timeSinceRead, 0, _readOutSpeed);
			
			// Read out the text if there is any.
			if (_textToRead.Length > 0 && _timeSinceRead >= _readOutSpeed)
			{
				_timeSinceRead = 0;
				// Append the first character of the text to read out to the text display.
				_targetText.text += _textToRead[0];
				// Remove the first character.
				_textToRead = _textToRead.Substring(1, _textToRead.Length - 1);
			}
		}
	}
}
