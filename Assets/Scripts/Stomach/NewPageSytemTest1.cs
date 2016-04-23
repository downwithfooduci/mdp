using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class NewPageSytemTest1 : MonoBehaviour {

	public int size;
	public Texture[] PageImage;	

	private List<Pages> PageList = new List<Pages>();



	// Use this for initialization
	void Start () {
		for(int i = 0; i<PageImage.Length; i++){
			PageList.Add (new Pages (PageImage [i]));
		}
	
	}

	// Update is called once per frame
	void Update () {
		Debug.Log("Number of Texture:" + PageList.Count);
	
	}
}

public class Pages : NewPageSytemTest1
{
	public Texture PageTextture;
	public Pages(Texture pageimage){
		PageTextture = pageimage;
	}
	public void setPage(Texture pageText){
		this.PageTextture = pageText;

	}

}
