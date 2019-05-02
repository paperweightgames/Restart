using UnityEngine;
using UnityEngine.SceneManagement;

public class Singleton : MonoBehaviour
{
	private static Singleton _instance;
	private void Awake()
	{
		if (_instance == null)
		{
			_instance = this;
			DontDestroyOnLoad(gameObject);
		}
		else
		{
			DestroyImmediate(gameObject);
		}
	}
}
