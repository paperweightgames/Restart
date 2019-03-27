using System;
using UnityEngine;
using UnityEngine.Events;

namespace Interaction {
	[Serializable]
	public class InteractionObject
	{
		[SerializeField] private string name;
		[SerializeField] private UnityEvent action;

		public string GetName()
		{
			return name;
		}
		public void Invoke()
		{
			action.Invoke();
		}
	}
}
