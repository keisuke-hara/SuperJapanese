using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MainCamera : MonoBehaviour {

	public Text scoreText; //Text用変数
	private int score = 0; //スコア計算用変数

	// Use this for initialization
	void Start () {
		scoreText.text = "Score: 0"; 
	}
	
	// Update is called once per frame
	void Update () {
		
	}

}
