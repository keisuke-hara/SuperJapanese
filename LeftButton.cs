using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LeftButton : MonoBehaviour {

	bool push = false;

	// Use this for initialization
	void Start () {

	}

	public void LButtonPushDown(){
		push = true;
	}

	public void LButtonPushUp(){
		push = false;
		GameObject.Find("player").SendMessage("ButtonUp");
	}

	// Update is called once per frame
	void Update () {
		if(push == true){
			GameObject.Find("player").SendMessage("LButtonPush");
		}
	}
}