using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RightButton : MonoBehaviour {

	bool push = false;

	// Use this for initialization
	void Start () {
		
	}

	public void RButtonPushDown(){
		push = true;
	}

	public void RButtonPushUp(){
		push = false;
		GameObject.Find("player").SendMessage("ButtonUp");
	}
	
	// Update is called once per frame
	void Update () {
		if(push == true){
		GameObject.Find("player").SendMessage("RButtonPush");
		}
	}
}
