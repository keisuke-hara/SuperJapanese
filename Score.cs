using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

	public Text scoreText;
	private int score;

	// Use this for initialization
	void Start () {
		score= 0;
	}

	void AddScore(int s){
		score = score + s; 
	}

	// Update is called once per frame
	void Update () {
		scoreText.text = "score" + score;
	}
}
