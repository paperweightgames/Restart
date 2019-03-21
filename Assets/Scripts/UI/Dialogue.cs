using UnityEngine;
using UnityEngine.UI;

namespace UI {
	public class Dialogue : MonoBehaviour
	{
		[SerializeField] private float textSpeed;
		[SerializeField] private GameObject speakerPrefab;
		private Text targetText;
		private float timeSinceText;
		private string textToSay;

		public void Say(string speaker, string message)
		{
			// Create the new dialogue.
			var prefab = Instantiate(speakerPrefab, gameObject.transform);
			// Get the text components.
			var childTextObjects = prefab.GetComponentsInChildren<Text>();
			// Set the speaker.
			childTextObjects[0].text = $"{speaker}:";
			// Set the target.
			targetText = childTextObjects[1];
			// Set the text.
			textToSay = message;
		}

		private void Start()
		{
			Say("Off", "Hello there stranger!");
		}

		private void Update()
		{
			timeSinceText = Mathf.Clamp(timeSinceText + Time.deltaTime, 0, textSpeed);
			
			if (timeSinceText >= textSpeed && textToSay.Length > 0)
			{
				timeSinceText = 0;
				targetText.text += textToSay[0];
				textToSay = textToSay.Substring(1);
			}
		}
	}
}
