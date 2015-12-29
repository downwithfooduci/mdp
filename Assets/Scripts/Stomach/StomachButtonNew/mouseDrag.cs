using UnityEngine;
using System.Collections;

public class mouseDrag : MonoBehaviour 
{
	
	private Vector3 screenPoint;
	private Vector3 offset;
    private Vector3 originalP;


    private bool isdrag = false;
    private int CellNum;
    public float speed;


    private CellButtons CB;


    void Start(){

        CB = FindObjectOfType(typeof(CellButtons)) as CellButtons;
        Debug.Log ("start");
        originalP = transform.position;

        offset = new Vector2(50,50);
	}

	
	void OnMouseDown(){
		Debug.Log("on mouse down");
		screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
		offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
        isdrag = false;
        Debug.Log (offset);
	}
	
	void OnMouseDrag(){
		//Debug.Log ("on mouse drag");
		Vector3 cursorPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
		Vector3 cursorPosition = Camera.main.ScreenToWorldPoint(cursorPoint) + offset;
		transform.position = cursorPosition;
        //isdrag = true;
		//Debug.Log (cursorPosition);
	}
	
    void OnMouseUp()
    {
        Debug.Log("on mouse up");
        //Vector3 cursorPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
        //Vector3 cursorPosition = Camera.main.ScreenToWorldPoint(cursorPoint) + offset;

        isdrag = true;

        transform.position = originalP;
        CB.checkMouseClick(CellNum);
        //Debug.Log(cursorPosition);
    }

    /*
        void update()
        {
            if (isdrag == false)
            {
                float step = speed * Time.deltaTime;
            }
        }
        */

    public bool getDrag()
    {
        return isdrag;
    }
    public void setDrag(bool DragState)
    {
        isdrag = DragState;
    }
    public void setCellNum(int a)
    {
        CellNum = a;
    }
}
