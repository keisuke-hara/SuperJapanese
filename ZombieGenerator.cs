using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieGenerator : MonoBehaviour {

	public GameObject Zombie_LV1;
	float span = 0.8f;
	float delta = 0;
	bool zombieFlg = false;

	// Use this for initialization
	void Start () {
		
	}

	public void Open(){
		zombieFlg = true;

	}

	// Update is called once per frame
	void Update () {
		if (zombieFlg == true) {
			this.delta += Time.deltaTime;
			if (this.delta > this.span) {
				this.delta = 0;
				GameObject go = Instantiate (Zombie_LV1) as GameObject;
				float x = Random.Range (150, 165);
				go.transform.position = new Vector2 (x, 10);
			}
		}
	}

}
