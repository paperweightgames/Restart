using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class NpcRotations : MonoBehaviour
{
	[SerializeField] private Transform _camera, _parent;
	[SerializeField] private Sprite _forward, _side, _back;
	private SpriteRenderer _spriteRenderer;

	private void Awake()
	{
		_spriteRenderer = GetComponent<SpriteRenderer>();
	}

	private void Update()
	{
		var relative = Quaternion.Inverse(_camera.rotation) * _parent.rotation;
		
		var yDifference = _parent.rotation.y - _camera.rotation.y;
		// Back.
		if (yDifference > -.2f && yDifference < .2f)
		{
			_spriteRenderer.sprite = _back;
			_spriteRenderer.flipX = false;
		}
		// Front.
		else if (yDifference > .9f || yDifference < -.9f)
		{
			_spriteRenderer.sprite = _forward;
			_spriteRenderer.flipX = false;
		}
		// Sides.
		else
		{
			_spriteRenderer.sprite = _side;
		}
	}
}