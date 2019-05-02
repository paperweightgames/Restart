using UnityEngine;

[RequireComponent(typeof(Light))]
public class TimeCycle : MonoBehaviour
{
	[SerializeField] private Vector3 _originalAngle;
	[SerializeField] private float _currentTime;
	[SerializeField] private float _dayLength;
	private Light _sun;

	public float GetTime()
	{
		return _currentTime;
	}

	public float GetDayLength()
	{
		return _dayLength;
	}

	private void Awake()
	{
		// Gets the reference to the Light component at the start of the game.
		_sun = GetComponent<Light>();
	}

	private void Update()
	{
		// Increase the current time.
		_currentTime += Time.deltaTime;
		var dayProgress = _currentTime % _dayLength / _dayLength;
		
		// Toggle the directional light based on the progress.
		_sun.enabled = dayProgress > .2f && dayProgress < .8f;
		
		// Work out the new angle for the directional light.
		var targetRotation = new Vector3(dayProgress * 360 + _originalAngle.x,
			_originalAngle.y,
			_originalAngle.z);
		_sun.transform.eulerAngles = targetRotation;
	}
}
