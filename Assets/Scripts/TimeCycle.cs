using UnityEngine;

[RequireComponent(typeof(Light))]
public class TimeCycle : MonoBehaviour
{
	[SerializeField] private float currentTime;
	[SerializeField] private float dayLength;
	private Light _sun;
	private Vector3 _originalAngle;

	private void Awake()
	{
		_sun = GetComponent<Light>();
		_originalAngle = _sun.transform.eulerAngles;
	}

	private void Update()
	{
		currentTime += Time.deltaTime;
		var newAngle = new Vector3(currentTime % dayLength / dayLength * 360, _originalAngle.y, _originalAngle.z);
		_sun.transform.eulerAngles = newAngle;
	}
}
