using UnityEngine;
using System.Collections;
using System.IO;

public class LoadScriptMouth 
{
	public LoadScriptMouth() {}
	
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

public class MouthWave
{
	public float startDelay;
	public float runTime;
	public float foodSpeed;
	public float foodSpawnInterval;
}

