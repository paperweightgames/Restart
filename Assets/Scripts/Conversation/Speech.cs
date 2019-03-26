using UI;
using UnityEngine;
using UnityEngine.UI;

namespace Conversation {
	[CreateAssetMenu(fileName = "Speech", menuName = "Conversation/Speech", order = 1)]
	public class Speech : ConversationElement
	{
		[SerializeField] private string speaker;
		[SerializeField, TextArea(3, 10)] private string speech;

		public override GameObject Display(Transform parent)
		{
			var conversationManager = FindObjectOfType<ConversationManager>();
			// Get the object.
			var prefab = base.Display(parent);
			// Set the speaker.
			var textComponents = prefab.GetComponentsInChildren<Text>();
			textComponents[0].text = $"{speaker}:";
			
			// Set the text.
			conversationManager.ReadOut(speech, textComponents[1]);
			return prefab;
		}
	}
}
