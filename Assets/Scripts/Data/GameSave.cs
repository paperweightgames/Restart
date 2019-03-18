using System;
using UnityEngine;

namespace Data
{
	[Serializable, CreateAssetMenu(fileName = "GameSave", menuName = "Data/GameSave", order = 1)]
	public class GameSave : ScriptableObject
	{
		public static GameSave current;
		public DateTime timeCreated;
		[Header("World Stats")]
		public float CurrentTime = 0;
		public float DayLength = 720;
		[Header("Player Stats")]
		public string PlayerName = "Charlie";
		public Vector3 Position = Vector3.zero;
		public float MaxHunger;
		public float Hunger;
		public float MaxThirst;
		public float Thirst;
		public int Money;
	}
}