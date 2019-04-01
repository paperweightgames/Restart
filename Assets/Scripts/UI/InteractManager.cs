using UnityEngine;
using UnityEngine.UI;

namespace UI {
	public class InteractManager : MonoBehaviour
	{
		[SerializeField] private string action;
		[SerializeField] private Color actionKeyColour;
		[SerializeField] private Text textComponent;
		[SerializeField] private GameObject interactObject;

		private void Start()
		{
			Hide();
		}

		public void Show(string newAction)
		{
			action = newAction;
			var colourHex = ColorUtility.ToHtmlStringRGB(actionKeyColour);
			textComponent.text = $"Press <color=#{colourHex}>E</color> to {action}.";
			interactObject.SetActive(true);
		}

		public void Hide()
		{
			action = null;
			interactObject.SetActive(false);
		}
	}
}
