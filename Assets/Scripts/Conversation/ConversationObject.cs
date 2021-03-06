﻿using UnityEngine;

namespace Conversation {
	[CreateAssetMenu(fileName = "Conversation", menuName = "Conversation/Conversation", order = 1)]
	public class ConversationObject : ScriptableObject
	{
		[SerializeField] private ConversationElement[] conversationElements;

		public ConversationElement[] GetElements()
		{
			return conversationElements;
		}
	}
}
