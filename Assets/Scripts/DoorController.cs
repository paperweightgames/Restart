using UnityEngine;

public class DoorController : MonoBehaviour
{
    [SerializeField] private GameObject _player;
    [SerializeField] private Animator _animator;
    
    private static readonly int Open = Animator.StringToHash("Open");
    private static readonly int Close = Animator.StringToHash("Close");

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == _player && !other.isTrigger)
        {
            _animator.SetTrigger(Open);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == _player && !other.isTrigger)
        {
            _animator.SetTrigger(Close);
        }
    }
}