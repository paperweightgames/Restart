using System.Collections.Generic;
using UI;
using UnityEngine;

namespace Interaction {
	public class InteractionReceiver : MonoBehaviour
	{
		[SerializeField] private List<InteractionObject> _interactions;
		[SerializeField] private InteractManager _interactManager;
		[SerializeField] private ConversationManager _conversationManager;

		public List<InteractionObject> GetInteractions()
		{
			return _interactions;
		}
		public void AddInteraction(InteractionObject interactionToAdd, GameObject sender)
		{
			interactionToAdd.SetSender(sender);
			_interactions.Add(interactionToAdd);
		}

		public void RemoveInteraction(InteractionObject interactionToRemove)
		{
			_interactions.Remove(interactionToRemove);
		}

		private void Update()
		{
			if (_interactions.Count > 0)
			{
				_interactManager.Show(_interactions[0].GetName());
				
				if (Input.GetKeyDown(KeyCode.E))
				{
					_interactions[0].Invoke();
				}
			}
			else
			{
				_interactManager.Hide();
				_conversationManager.EndConversation();
			}
		}
	}
}
