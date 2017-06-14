using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class retryButton : MonoBehaviour {

	public Button RetryButton;

	void Start () {
		gameObject.GetComponent<Button>().enabled = false;
	}

	// Update is called once per frame
	void Update () {

	}

	public void Lose(){
		gameObject.GetComponent<Button>().enabled = true;
	}
}
