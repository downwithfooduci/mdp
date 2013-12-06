using UnityEngine;
using System.Collections;
using System.IO;

public class LoadScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public Wave[] loadIntestineLevel(int level)
	{
		StreamReader sr = new StreamReader(Application.dataPath + "/Intestine/Levels/Level" + level + ".txt");
		string fileContents = sr.ReadToEnd();
		sr.Close();
		
		string[] lines = fileContents.Split("\n"[0]);

		Wave[] waves = new Wave[lines.Length];

		for(int j = 0; j < lines.Length; j++)
		{
			Wave wave = new Wave();

			string[] waveInfo = lines[j].Split("/"[0]);
			wave.startDelay = float.Parse(waveInfo[0]);
			wave.runTime = float.Parse(waveInfo[1]);
			wave.nutrientSpeed = float.Parse(waveInfo[2]);
			wave.nutrientSpawnInterval = float.Parse(waveInfo[3]);
			wave.minBlobs = int.Parse(waveInfo[4]);
			wave.maxBlobs = int.Parse(waveInfo[5]);

			Color[] colors = new Color[(waveInfo[6].Length) - 1];
			for(int k = 0; k < colors.Length; k++)
			{
				switch (waveInfo[6][k])
				{
				case 'R':
					colors[k] = Color.red;
					break;
				case 'Y':
					colors[k] = Color.yellow;
					break;
				case 'G':
					colors[k] = Color.green;
					break;
				}
			}
			wave.colors = colors;
			waves[j] = wave;
		}
		return waves;
	}
}

public class Wave
{
	public float startDelay;
	public float runTime;
	public float nutrientSpeed;
	public float nutrientSpawnInterval;
	public int minBlobs;
	public int maxBlobs;
	public Color[] colors;
}
