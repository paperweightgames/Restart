using UnityEngine;
using UnityEngine.UI;

namespace Conversation {
	[CreateAssetMenu(fileName = "Options", menuName = "Conversation/Options", order = 1)]
	public class Options : ConversationElement
	{
		[SerializeField] private Option[] options;
	}
}
