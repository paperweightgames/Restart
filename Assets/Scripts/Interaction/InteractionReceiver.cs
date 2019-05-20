using System.Collections.Generic;
using UI;
using UnityEngine;

namespace Interaction {
	public class InteractionReceiver : MonoBehaviour
	{
		[SerializeField] private List<InteractionObject> interactions;
		[SerializeField] private InteractManager interactManager;
		[SerializeField] private ConversationManager _conversationManager;

		public void AddInteraction(InteractionObject interactionToAdd)
		{
			interactions.Add(interactionToAdd);
		}

		public void RemoveInteraction(InteractionObject interactionToRemove)
		{
			interactions.Remove(interactionToRemove);
		}

		private void Update()
		{
			if (interactions.Count > 0)
			{
				interactManager.Show(interactions[0].GetName());
				
				if (Input.GetKeyDown(KeyCode.E))
				{
					interactions[0].Invoke();
				}
			}
			else
			{
				interactManager.Hide();
				_conversationManager.EndConversation();
			}
		}
	}
}
