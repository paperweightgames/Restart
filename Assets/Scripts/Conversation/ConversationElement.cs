using UnityEngine;

namespace Conversation {
	public class ConversationElement : ScriptableObject
	{
		[SerializeField] private GameObject prefab;

		public virtual GameObject Display(Transform parent)
		{
			prefab = Instantiate(prefab, parent);
			return prefab;
		}
	}
}
