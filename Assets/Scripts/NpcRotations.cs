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
		var yDifference = Mathf.Abs(_camera.rotation.y) - Mathf.Abs(_parent.rotation.y);
		//yDifference = Mathf.Abs(yDifference);
		print(yDifference);
		// Back.
		if (yDifference < .2f)
		{
			_spriteRenderer.sprite = _back;
			_spriteRenderer.flipX = false;
		}
		// Front.
		else if (yDifference > .8f)
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