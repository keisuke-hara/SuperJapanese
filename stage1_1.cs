using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stage1_1 : MonoBehaviour {

	public GameObject stage1_2;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			Destroy (gameObject);
			Instantiate (stage1_2, transform.position, transform.rotation);
		}
	}
}
