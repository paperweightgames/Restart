using UnityEngine;
using UnityEngine.Events;

namespace Interaction
{
	public class InteractionTransmitter : MonoBehaviour
	{
		[SerializeField] private InteractionObject interaction;

		private void OnTriggerEnter(Collider other)
		{
			if (other.CompareTag("Player"))
			{
				other.GetComponent<InteractionReceiver>().AddInteraction(interaction);
			}
		}

		private void OnTriggerExit(Collider other)
		{
			if (other.CompareTag("Player"))
			{
				other.GetComponent<InteractionReceiver>().RemoveInteraction(interaction);
			}
		}
	}
}