using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class titleButton : MonoBehaviour {

	void Start () {
		gameObject.GetComponent<Text>().enabled = false;
	}

	// Update is called once per frame
	void Update () {

	}

	public void Lose(){
		gameObject.GetComponent<Text>().enabled = true;
	}
}
