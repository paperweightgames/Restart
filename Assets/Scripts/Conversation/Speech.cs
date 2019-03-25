using UI;
using UnityEngine;
using UnityEngine.UI;

namespace Conversation {
	[CreateAssetMenu(fileName = "Speech", menuName = "Conversation/Speech", order = 1)]
	public class Speech : ConversationElement
	{
		[SerializeField] private string speaker;
		[SerializeField] private ConversationManager conversationManager;
		[SerializeField, TextArea(3, 10)] private string speech;

		public override GameObject Display(Transform parent)
		{
			// Get the object.
			var prefab =  base.Display(parent);
			// Set the speaker.
			prefab.GetComponentsInChildren<Text>()[0].text = $"{speaker}:";
			return prefab;
			// Set the text.
			
		}
	}
}
