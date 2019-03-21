using UnityEngine;
using UnityEngine.UI;

namespace UI {
	public class Dialogue : MonoBehaviour
	{
		[SerializeField] private float textSpeed;
		[SerializeField] private GameObject speakerPrefab;
		private Image _box;
		private Text _targetText;
		private float _timeSinceText;
		private string _textToSay;

		private void Awake()
		{
			_box = GetComponent<Image>();
		}

		public void Say(string speaker, string message)
		{
			// Create the new dialogue.
			var prefab = Instantiate(speakerPrefab, gameObject.transform);
			// Get the text components.
			var childTextObjects = prefab.GetComponentsInChildren<Text>();
			// Set the speaker.
			childTextObjects[0].text = $"{speaker}:";
			// Set the target.
			_targetText = childTextObjects[1];
			// Set the text.
			_textToSay = message;
		}

		private void Start()
		{
			Say("Off", "Hello there stranger!");
		}

		private void Update()
		{
			_timeSinceText = Mathf.Clamp(_timeSinceText + Time.deltaTime, 0, textSpeed);

			// Enable the box if there is text to display.
			_box.enabled = transform.childCount > 0; 
			
			if (_timeSinceText >= textSpeed && _textToSay.Length > 0)
			{
				_timeSinceText = 0;
				_targetText.text += _textToSay[0];
				_textToSay = _textToSay.Substring(1);
			}
		}
	}
}
