using UnityEngine;
using UnityEngine.SceneManagement;

namespace UI
{
	public class MenuManager : MonoBehaviour
	{
		[SerializeField] private GameObject currentMenu;

		private void Start()
		{
			ChangeMenu(currentMenu);
		}

		public void LoadScene(int sceneIndex)
		{
			SceneManager.LoadScene(sceneIndex);
		}

		public void ChangeMenu(GameObject targetMenu)
		{
			// Disable the current panel.
			currentMenu.SetActive(false);
			// Change the current panel.
			currentMenu = targetMenu;
			// Enable the new panel.
			currentMenu.SetActive(true);
		}
		
		public void Quit()
		{
			Application.Quit();
		}
	}
}
