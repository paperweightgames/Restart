using UnityEngine;

namespace Interaction {
	public class InteractionReceiver : MonoBehaviour
	{
		private void OnTriggerEnter(Collider other)
		{
			if (other.CompareTag("Intractable"))
			{
				other.GetComponent<InteractionTransmitter>().Enter();
			}
		}

		private void OnTriggerStay(Collider other)
		{
			if (other.CompareTag("Intractable") && Input.GetKeyDown(KeyCode.E))
			{
				other.GetComponent<InteractionTransmitter>().Interact();
			}
		}
	}
}
