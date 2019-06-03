using Interaction;
using UnityEngine;

namespace Player
{
    public class PlayerInteracting : MonoBehaviour
    {
        [SerializeField] private InteractionReceiver _interactionReceiver;
        private GameObject _target;

        public GameObject IsBegging()
        {
            var interactions = _interactionReceiver.GetInteractions();

            foreach (var interaction in interactions)
            {
                if (interaction.GetName() == "Beg")
                {
                    return interaction.GetSender();
                }
            }

            return null;
        }
    }
}