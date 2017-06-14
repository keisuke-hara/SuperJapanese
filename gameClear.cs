using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gameClear : MonoBehaviour {

	public Text gameClearText;
	bool gameClearFlg = false;

	// Use this for initialization
	void Start () {
		gameObject.GetComponent<Text>().enabled = false;
	}

	// Update is called once per frame
	void Update () {
		if (gameClearFlg == true && Input.GetMouseButtonDown(0)) {
			Application.LoadLevel ("title");
		}

	}

	public void Win(){
		gameObject.GetComponent<Text>().enabled = true;
		gameClearFlg = true;

	}
}
