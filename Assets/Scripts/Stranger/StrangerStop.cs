using UnityEngine;
using UnityEngine.AI;

namespace Stranger {
	[RequireComponent(typeof(NavMeshAgent))]
	public class StrangerStop : MonoBehaviour
	{
		private NavMeshAgent _navMeshAgent;
		[SerializeField] private string _playerTag;

		private void Awake()
		{
			_navMeshAgent = GetComponent<NavMeshAgent>();
		}

		private void OnTriggerEnter(Collider other)
		{
			if (other.CompareTag(_playerTag))
			{
				_navMeshAgent.isStopped = true;
			}
		}

		private void OnTriggerExit(Collider other)
		{
			if (other.CompareTag(_playerTag))
			{
				_navMeshAgent.isStopped = false;
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
