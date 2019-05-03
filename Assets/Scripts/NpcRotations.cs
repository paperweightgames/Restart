using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class NpcRotations : MonoBehaviour
{
	[SerializeField] private Transform _camera, _parent;
	[SerializeField] private Sprite _forward, _side, _back;
	private SpriteRenderer _spriteRenderer;

	private void Update()
	{
		print(_camera.rotation.x);
	}
}