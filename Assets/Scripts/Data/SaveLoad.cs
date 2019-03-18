using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine;

namespace Data
{
	public static class SaveLoad
	{
		private static readonly string SaveFilePath = Path.Combine(Application.persistentDataPath, "saves.rsf");
		private static List<GameSave> _savedGames = new List<GameSave>();

		public static void Save()
		{
			_savedGames.Add(GameSave.current);
			var bf = new BinaryFormatter();
			var file = File.Create(SaveFilePath);
			bf.Serialize(file, _savedGames);
			file.Close();
		}

		public static void Load()
		{
			// Check if the file exists.
			if (!File.Exists(SaveFilePath)) return;
			var bf = new BinaryFormatter();
			var file = File.Open(SaveFilePath, FileMode.Open);
			_savedGames = (List<GameSave>) bf.Deserialize(file);
			file.Close();
		}
	}
}