using UnityEngine;

[RequireComponent(typeof(Light))]
public class TimeCycle : MonoBehaviour
{
	[SerializeField] private float _currentTime;
	[SerializeField] private float dayLength;
	[SerializeField] private float _speedMultiplier;
	private Light _sun;
	private Vector3 _originalAngle;

	public float GetTime()
	{
		return _currentTime;
	}

	public float GetDayLength()
	{
		return dayLength;
	}

	private void Awake()
	{
		// Gets the reference to the Light component at the start of the game.
		_sun = GetComponent<Light>();
		_originalAngle = _sun.transform.eulerAngles;
	}

	private void Update()
	{
		// Increase the current time.
		_currentTime += Time.deltaTime * _speedMultiplier;
		var dayProgress = _currentTime % dayLength / dayLength;
		
		// Toggle the directional light based on the progress.
		_sun.enabled = dayProgress > .2f && dayProgress < .8f;
		
		// Work out the new angle for the directional light.
		var targetRotation = new Vector3(dayProgress * 360 + _originalAngle.x,
			_originalAngle.y,
			_originalAngle.z);
		_sun.transform.eulerAngles = targetRotation;
	}
}
