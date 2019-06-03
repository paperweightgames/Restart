using UnityEngine;
using UnityEngine.Events;

namespace Interaction
{
	public class InteractionTransmitter : MonoBehaviour
	{
		[SerializeField] private InteractionObject _interaction;

		private void OnTriggerEnter(Collider other)
		{
			if (other.CompareTag("Player"))
			{
				other.GetComponent<InteractionReceiver>().AddInteraction(_interaction, gameObject);
			}
		}

		private void OnTriggerExit(Collider other)
		{
			if (other.CompareTag("Player"))
			{
				other.GetComponent<InteractionReceiver>().RemoveInteraction(_interaction);
			}
		}

		public void SetInteraction(InteractionObject newInteraction)
		{
			_interaction = newInteraction;
		}
	}
}