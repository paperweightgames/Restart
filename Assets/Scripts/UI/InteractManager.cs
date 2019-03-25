using UnityEngine;
using UnityEngine.UI;

namespace UI {
	public class InteractManager : MonoBehaviour
	{
		[SerializeField] private string action;
		[SerializeField] private Text textComponent;
		[SerializeField] private GameObject interactObject;

		public void Show(string newAction)
		{
			action = newAction;
			textComponent.text = $"Press <color=#E4943A>E</color> to {action}.";
			interactObject.SetActive(true);
		}

		public void Hide()
		{
			action = null;
			interactObject.SetActive(false);
		}
	}
}
