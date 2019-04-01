using UnityEngine;

[RequireComponent(typeof(Light))]
public class TimeCycle : MonoBehaviour
{
	[SerializeField] private float currentTime;
	[SerializeField] private float dayLength;
	private Light _sun;
	private Vector3 _originalAngle;

	public float GetTime()
	{
		return currentTime;
	}

	public float GetDayLength()
	{
		return dayLength;
	}

	private void Awake()
	{
		_sun = GetComponent<Light>();
		_originalAngle = _sun.transform.eulerAngles;
	}

	private void Update()
	{
		// Increase the current time.
		currentTime += Time.deltaTime;
		var dayProgress = currentTime % dayLength / dayLength;
		// Toggle the directional light based on the progress.
		_sun.enabled = dayProgress > .2f && dayProgress < .8f;
		// Work out the new angle for the directional light.
		var targetRotation = new Vector3(dayProgress * 360 + _originalAngle.x,
			_originalAngle.y,
			_originalAngle.z);
		_sun.transform.eulerAngles = targetRotation;
	}
}
