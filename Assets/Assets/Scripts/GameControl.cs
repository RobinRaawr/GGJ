using UnityEngine;
using System.Collections;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class GameControl : MonoBehaviour {

	public static GameControl control;

	public GameObject Player1, Player2, Rope;

	public string name;
	public float score;
	public float highscore;

	void Awake()
	{
		control = this;
	}

	public void Save()
	{
		BinaryFormatter bf = new BinaryFormatter ();
		FileStream file = File.Create (Application.persistentDataPath + "/playerInfo.dat");

		PlayerData data = new PlayerData ();
		data.name = name;
		data.score = score;

		bf.Serialize (file, data);
		file.Close();
	}

	public void Load()
	{
		if(File.Exists(Application.persistentDataPath + "/playerInfo.dat"))
		{
			BinaryFormatter bf = new BinaryFormatter();
			FileStream file = File.Open(Application.persistentDataPath + "/playerInfo.dat", FileMode.Open);
			PlayerData data = (PlayerData)bf.Deserialize(file);
			file.Close();

			name = data.name;
			highscore = data.score;
		}
	}
}

[Serializable]
class PlayerData
{
	public string name;
	public float score;
}
