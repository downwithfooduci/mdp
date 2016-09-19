using UnityEngine;
using System.Collections;
using System.IO;
using System;
using System.Runtime.Serialization.Formatters.Binary;


public class BadgeDataIO : MonoBehaviour {

	public int badgeNums;
	private FileStream dataStream;
	private bool[] localBadgeList;


	// Use this for initialization
	void Start () {
		badgeNums = 13;
		localBadgeList = new bool[13];


		//Save ();

		Debug.Log (" badge Length " + localBadgeList.Length + "before load");
		Load ();

		Debug.Log (" badge Length " + localBadgeList.Length + "after load");

		//Debug.Log (" badge Length " + localBadgeList.Length + "before load");
		//Load ();
		//Debug.Log (" badge Length " + localBadgeList.Length + "after load");


	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void Load(){
		if (!File.Exists (Application.persistentDataPath + "/badgeData.dat")) {
			/*
			 dataStream = File.Create (Application.persistentDataPath + "/badgeData.dat");
			Debug.Log ("File " + Application.persistentDataPath + "/badgeData.dat" + " created");

			badgeData data = new badgeData (badgeNums);
			*/
			Save ();
		}

			
		dataStream = File.Open (Application.persistentDataPath + "/badgeData.dat", FileMode.Open);

		Debug.Log ("File " + Application.persistentDataPath + "/badgeData.dat" + " loaded");

		BinaryFormatter bf = new BinaryFormatter ();
		badgeData data = (badgeData)bf.Deserialize( dataStream);

		dataStream.Close();
		localBadgeList = data.badgeList;//localBadgeList = data.returnList ();

	}

	void Save(){

		BinaryFormatter bf = new BinaryFormatter ();
		dataStream = File.Create (Application.persistentDataPath + "/badgeData.dat");

		Debug.Log ("File " + Application.persistentDataPath + "/badgeData.dat" + " created");


		badgeData data = new badgeData ();
		data.badgeList = localBadgeList; //data.setList (localBadgeList);



		Debug.Log ("badge Length " + data.badgeList.Length + "before save");

		bf.Serialize (dataStream, data);
		dataStream.Close ();

	}

	public void setBadgeByNum(int num){
		if (num >= localBadgeList.Length) {
			Debug.Log (num + "excess badge Length " + localBadgeList.Length + ", set failed.");
			return;
		}
		localBadgeList [num] = localBadgeList[num] == false ? true : false;

		Save ();

	}

	public bool returnBadgeStatus(int num){
		if (num >= localBadgeList.Length) {
			Debug.Log (num + "excess badge Length " + localBadgeList.Length + ", set failed.");
			return false;
		}
		return localBadgeList [num];
	}



	[Serializable]
	class badgeData{
		public bool[] badgeList;

		/*
		public badgeData(){
			badgeList = new bool[13];
		}


		public bool[] returnList(){
			return badgeList;
		}
		public void setList(bool[] list){
			for (int i = 0; i < list.Length; i++) {
				badgeList [i] = list [i];
			}
		}
		*/

	}


}
