using UnityEngine;
using UnityEngine.AI;

namespace Stranger {
	[RequireComponent(typeof(NavMeshAgent))]
	public class StrangerStop : MonoBehaviour
	{
		[SerializeField] private Animator _animator;
		[SerializeField] private string _playerTag;
		private NavMeshAgent _navMeshAgent;
		// Animation index.
		private static readonly int Walk = Animator.StringToHash("Walk");
		private static readonly int Idle = Animator.StringToHash("Idle");

		private void Awake()
		{
			_navMeshAgent = GetComponent<NavMeshAgent>();
		}

		private void OnTriggerEnter(Collider other)
		{
			if (other.CompareTag(_playerTag))
			{
				_navMeshAgent.isStopped = true;
				_animator.SetTrigger(Idle);
			}
		}

		private void OnTriggerExit(Collider other)
		{
			if (other.CompareTag(_playerTag))
			{
				_navMeshAgent.isStopped = false;
				_animator.SetTrigger(Walk);
			}
		}

		private void OnTriggerStay(Collider other)
		{
			if (other.CompareTag(_playerTag))
			{
				transform.LookAt(other.transform);
			}
		}
	}
}
