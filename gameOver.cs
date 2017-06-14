using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gameOver : MonoBehaviour {

	public Text gameOverText;
	bool gameOverFlg = false;

	// Use this for initialization
	void Start () {
		gameObject.GetComponent<Text>().enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (gameOverFlg == true && Input.GetMouseButtonDown(0)) {
			Application.LoadLevel ("title");
		}
		
	}

	public void Lose(){
		gameObject.GetComponent<Text>().enabled = true;
		gameOverFlg = true;

	}
}
