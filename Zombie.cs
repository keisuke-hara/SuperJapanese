using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour {

	Rigidbody2D rigid2D;
	public int speed = -1;
	public GameObject zombie_dead;


	//メインカメラのタグ名　constは定数(絶対に変わらない値)
	private const string MAIN_CAMERA_TAG_NAME = "MainCamera";
	//カメラに映っているかの判定
	private bool _isRendered = false;


	// Use this for initialization
	void Start () {
		this.rigid2D = GetComponent<Rigidbody2D> ();
		
	}
	
	// Update is called once per frame
	void Update () {

		if (_isRendered) {
			rigid2D.velocity = new Vector2 (speed, rigid2D.velocity.y);
		}
		if (gameObject.transform.position.y < Camera.main.transform.position.y - 8 ||
			gameObject.transform.position.x < Camera.main.transform.position.x - 10) {
			Destroy(gameObject);
		}
	}

	void OnTriggerEnter2D (Collider2D col)
	{
		if (col.tag == "Bullet") {
			Destroy (gameObject);
			Instantiate (zombie_dead, transform.position, transform.rotation);
		}
	}

	//Rendererがカメラに映ってる間に呼ばれ続ける
	void OnWillRenderObject()
	{
		//メインカメラに映った時だけ_isRenderedをtrue
		if(Camera.current.tag == MAIN_CAMERA_TAG_NAME){
			_isRendered = true;
		}
	}

}
