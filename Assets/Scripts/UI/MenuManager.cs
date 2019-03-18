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

		public void StartGame(int sceneIndex)
		{
			SceneManager.LoadScene(sceneIndex);
		}

		public void ChangeMenu(GameObject targetMenu)
		{
			currentMenu.SetActive(false);
			currentMenu = targetMenu;
			currentMenu.SetActive(true);
		}
		
		public void Quit()
		{
			Application.Quit();
		}
	}
}
