using UnityEngine;
using System.Collections;
using System.IO;

public class LoadScript{

	public LoadScript()
	{
	}

	public SIWave[] loadIntestineLevel(int level)
	{
		TextAsset lev = Resources.Load ("SILevel" + level) as TextAsset;  // for ipad we need to load resources instead of using a file

		StringReader reader = new StringReader (lev.text);

		string[] lines = lev.text.Split("\n"[0]);	// split just to count number of lines to create waves array

		SIWave[] waves = new SIWave[lines.Length];

		string line;	// store the content of the current line
		int j = 0;  	// index for lines array
		while((line = reader.ReadLine()) != null)
		{
			SIWave wave = new SIWave();			// object that holds all information about a given wave

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
		return waves;
	}

	public MouthWave[] loadMouthLevel(int level)
	{
		TextAsset lev = Resources.Load ("MouthLevel" + level) as TextAsset;  // for ipad we need to load resources instead of using a file

		StringReader reader = new StringReader (lev.text);
		
		string[] lines = lev.text.Split("\n"[0]);	// split just to count number of lines to create waves array
		
		MouthWave[] waves = new MouthWave[lines.Length];
		
		string line;	// store the content of the current line
		int j = 0;  	// index for lines array
		while((line = reader.ReadLine()) != null)
		{
			MouthWave wave = new MouthWave();			// object that holds all information about a given wave
			
			string[] waveInfo = line.Split("/"[0]);			// split the current wave line for easier parsing
			wave.startDelay = float.Parse(waveInfo[0]);
			wave.runTime = float.Parse(waveInfo[1]);
			wave.foodSpeed = float.Parse(waveInfo[2]);
			wave.foodSpawnInterval = float.Parse(waveInfo[3]);

			waves[j] = wave;
			j++;
		}
		return waves;
	}
}


public class SIWave
{
	public float startDelay;
	public float runTime;
	public float nutrientSpeed;
	public float nutrientSpawnInterval;
	public int minBlobs;
	public int maxBlobs;
	public Color[] colors;
}

public class MouthWave
{
	public float startDelay;
	public float runTime;
	public float foodSpeed;
	public float foodSpawnInterval;
}
