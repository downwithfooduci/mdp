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
		TextAsset lev = Resources.Load ("Level" + level) as TextAsset;  // for ipad we need to load resources instead of using a file

		StringReader reader = new StringReader (lev.text);

		string[] lines = lev.text.Split("\n"[0]);	// split just to count number of lines to create waves array

		Wave[] waves = new Wave[lines.Length];

		string line;	// store the content of the current line
		int j = 0;  	// index for lines array
		while((line = reader.ReadLine()) != null)
		{
			Wave wave = new Wave();			// object that holds all information about a given wave

			string[] waveInfo = line.Split("/"[0]);			// split the current wave line for easier parsing
			wave.startDelay = float.Parse(waveInfo[0]);
			wave.runTime = float.Parse(waveInfo[1]);
			wave.nutrientSpeed = float.Parse(waveInfo[2]);
			wave.nutrientSpawnInterval = float.Parse(waveInfo[3]);
			wave.minBlobs = int.Parse(waveInfo[4]);
			wave.maxBlobs = int.Parse(waveInfo[5]);

			Color[] colors = new Color[(waveInfo[6].Length)];

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
			j++;
		}
		Debug.Log("NUMBER OF WAVES " + waves.Length);
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
