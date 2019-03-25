using UnityEngine;
using UnityEngine.Events;

namespace Interaction
{
	public class InteractionTransmitter : MonoBehaviour
	{
		[SerializeField] private UnityEvent onEnter;
		[SerializeField] private UnityEvent onInteract;

		public void Enter()
		{
			onEnter.Invoke();
		}

		public void Interact()
		{
			onInteract.Invoke();
		}
	}
}