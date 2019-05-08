using UnityEngine;

public class DebugLine : MonoBehaviour
{
	[SerializeField] private float _length;
	[SerializeField] private Color _lineColour;
	private void Update()
	{
		var transform1 = transform;
		var position = transform1.position;
		var endPoint = position + transform1.forward * _length;
		Debug.DrawLine(position, endPoint, _lineColour);
	}
}