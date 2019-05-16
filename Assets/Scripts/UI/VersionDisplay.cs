using UnityEngine;
using UnityEngine.UI;

namespace UI {
	[RequireComponent(typeof(Text))]
	public class VersionDisplay : MonoBehaviour
	{
		private Text _displayText;
		[SerializeField] private string _formatting;

		private void Awake()
		{
			_displayText = GetComponent<Text>();
		}

		private void Start()
		{
			var version = Application.version;
			_displayText.text = string.Format(_formatting, version);
		}
	}
}
