using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class player : MonoBehaviour {

	Rigidbody2D rigid2D;
	Animator animator;
	float jumpForce = 325.0f;
	float walkForce = 50.0f;
	float maxWalkSpeed = 5.5f;

	public GameObject mainCamera;
	public GameObject bullet;
	public LayerMask groundLayer; //Linecastで判定するLayer
	public LayerMask frameLayer; //Linecastで判定するLayer
	public GameObject player_dead;
	public GameObject player_goal;

	bool push = false;

	private bool isGrounded; //着地判定
	private bool isFramed; //フレーム接触判定




	// Use this for initialization
	void Start () {
		this.rigid2D = GetComponent<Rigidbody2D> ();
		this.animator = GetComponent<Animator> ();
	}



	// Update is called once per frame
	void Update () {



		//Linecastでプレイヤーの足元にフレームがあるか判定
		isFramed = Physics2D.Linecast (
			transform.position + transform.up * 1,
			transform.position - transform.up * 0.05f,
			frameLayer);
		
		//Linecastでプレイヤーがフレームに触れていたら破壊
		if (isFramed) {
			Destroy(gameObject);
			GameObject.Find("GameOver").SendMessage("Lose");
		}

			
		//Linecastでプレイヤーの足元に地面があるか判定
		isGrounded = Physics2D.Linecast (
			transform.position + transform.up * 1,
			transform.position - transform.up * 0.05f,
			groundLayer);
		
		//上下への移動速度を取得
		float velY = rigid2D.velocity.y;
		//移動速度が0.1より大きければ上昇
		bool isJumping = velY > 0.1f ? true:false;
		//移動速度が-0.1より小さければ下降
		bool isFalling = velY < -0.1f ? true:false;
		//結果をアニメータービューの変数へ反映する
		animator.SetBool("isJumping Bool",isJumping);
		animator.SetBool("isFalling Bool",isFalling);


		//画面中央から左に4移動した位置をユニティちゃんが超えたら
		if (transform.position.x > mainCamera.transform.position.x - 4) {
			//カメラの位置を取得
			Vector3 cameraPos = mainCamera.transform.position;
			//プレイヤーの位置から右に4移動した位置を画面中央にする
			cameraPos.x = transform.position.x + 4;
			mainCamera.transform.position = cameraPos;
		}

		if (transform.position.y < 0) {
			//カメラの位置を取得
			Vector3 cameraPos = mainCamera.transform.position;
			//プレイヤーの位置から右に4移動した位置を画面中央にする
			cameraPos.y = 0;
			mainCamera.transform.position = cameraPos;
		} else {
			Vector3 cameraPos = mainCamera.transform.position;
			//プレイヤーの位置から右に4移動した位置を画面中央にする
			cameraPos.y = transform.position.y;
			mainCamera.transform.position = cameraPos;
		}



		//カメラ表示領域の左下をワールド座標に変換
		Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
		//カメラ表示領域の右上をワールド座標に変換
		Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));
		//プレイヤーのポジションを取得
		Vector2 pos = transform.position;
		//プレイヤーのx座標の移動範囲をClampメソッドで制限
		pos.x = Mathf.Clamp(pos.x, min.x + 0.5f, max.x);
		transform.position = pos;



	}

	public void AttackButtonDown(){
		animator.SetTrigger("Attack Trigger");
		Instantiate(bullet, transform.position + new Vector3(0.1f,2.2f,0f), transform.rotation);
	}

	public void JumpButtonDown(){

		if(this.rigid2D.velocity.y == 0){
		this.animator.SetTrigger ("Jump Trigger");
		this.rigid2D.AddForce (transform.up * jumpForce);
		}

		if (isGrounded) {
			//Dashアニメーションを止めて、Jumpアニメーションを実行
			animator.SetBool("Walk Bool", false);
			animator.SetTrigger("Jump Trigger");
			//着地判定をfalse
			isGrounded = false;
			//AddForceにて上方向へ力を加える
			rigid2D.AddForce (Vector2.up * jumpForce);
		}

	}




	public void RButtonPush(){
		float x = 1;

		//左か右を入力したら
		if (x != 0) {
			//入力方向へ移動
			float speedx = Mathf.Abs (this.rigid2D.velocity.x);

			if (speedx < this.maxWalkSpeed) {
				this.rigid2D.AddForce (transform.right * x * this.walkForce);
			}

			this.animator.speed = speedx / 7.0f;

			//localScale.xを-1にすると画像が反転する
			Vector2 temp = transform.localScale;
			temp.x = x;
			transform.localScale = temp;
			//Wait→Dash
			animator.SetBool ("Walk Bool", true);
			//左も右も入力していなかったら
		} else {
			//横移動の速度を0にしてピタッと止まるようにする
			rigid2D.velocity = new Vector2 (0, rigid2D.velocity.y);
			//Dash→Wait
			animator.SetBool ("Walk Bool", false);
		}
	}


	public void LButtonPush(){
	
	float x = -1;

	//左か右を入力したら
	if (x != 0) {
		//入力方向へ移動
		float speedx = Mathf.Abs (this.rigid2D.velocity.x);

		if (speedx < this.maxWalkSpeed) {
			this.rigid2D.AddForce (transform.right * x * this.walkForce);
		}

		this.animator.speed = speedx / 7.0f;

		//localScale.xを-1にすると画像が反転する
		Vector2 temp = transform.localScale;
		temp.x = x;
		transform.localScale = temp;
		//Wait→Dash
		animator.SetBool ("Walk Bool", true);
		}
	}

	public void ButtonUp(){
		rigid2D.velocity = new Vector2 (0, rigid2D.velocity.y);
		//Dash→Wait
		animator.SetBool ("Walk Bool", false);
		
	}



	void OnTriggerEnter2D (Collider2D col)
	{
		if (col.gameObject.tag == "Enemy") {
			Destroy(gameObject);
			Instantiate (player_dead, transform.position, transform.rotation);

			GameObject.Find("GameOver").SendMessage("Lose");
		}
		if (col.gameObject.tag == "point_1000") {
			GameObject.Find("Score").SendMessage("AddScore", 1000);
		}
		if (col.gameObject.tag == "point_5000") {
			GameObject.Find("Score").SendMessage("AddScore", 5000);
		}
		if (col.gameObject.tag == "point_10000") {
			GameObject.Find("Score").SendMessage("AddScore", 10000);
		}

		if (col.gameObject.tag == "Goal") {
			GameObject.Find("GameClear").SendMessage("Win");
			Destroy(gameObject);
			Instantiate (player_goal, transform.position, transform.rotation);
		}

		if (col.gameObject.tag == "Open") {
			GameObject.Find("zombie_generator").SendMessage("Open");
		}


	}

	void OnCollisionEnter2D (Collision2D col)
	{
		
	}



}
