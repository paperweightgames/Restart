using UI;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Conversation {
	[CreateAssetMenu(fileName = "Action", menuName = "Conversation/Action", order = 1)]
	public class Action : ConversationElement
	{
		[SerializeField] private UnityEvent action;

		public override GameObject Display(Transform parent)
		{
			action.Invoke();
			var prefab = base.Display(parent);
			return prefab;
		}
	}
}
