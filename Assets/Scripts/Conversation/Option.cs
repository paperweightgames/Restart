using UnityEngine;
using UnityEngine.UI;

namespace Conversation {
	[CreateAssetMenu(fileName = "Option", menuName = "Conversation/Option", order = 1)]
	public class Option : ScriptableObject
	{
		[SerializeField] private string _text;
		[SerializeField] private Button.ButtonClickedEvent _event;
	}
}
