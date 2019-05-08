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
		var yDifference = _camera.rotation.y - _parent.rotation.y;
		// Back.
		if (yDifference > -.25f && yDifference < .25f)
		{
			_spriteRenderer.sprite = _back;
		}
		else if (yDifference > .75f || yDifference < -.75f)
		{
			_spriteRenderer.sprite = _forward;
		}
		else
		{
			_spriteRenderer.sprite = _side;
		}
		print(yDifference);
	}
}