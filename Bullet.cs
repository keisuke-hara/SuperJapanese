using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
	
	private GameObject player;
	private int speed = 8;

	void Start () {
		//ユニティちゃんオブジェクトを取得
		player = GameObject.FindWithTag("Player");
		//rigidbody2Dコンポーネントを取得
		Rigidbody2D rigidbody2D = GetComponent<Rigidbody2D>();
		//ユニティちゃんの向いている向きに弾を飛ばす
		rigidbody2D.velocity = new Vector2 (speed * player.transform.localScale.x, rigidbody2D.velocity.y);
		//画像の向きをユニティちゃんに合わせる
		Vector2 temp = transform.localScale;
		temp.x = player.transform.localScale.x;
		transform.localScale = temp;
		//5秒後に消滅
		Destroy(gameObject, 1);
	}

	void OnTriggerEnter2D (Collider2D col)
	{
		if (col.gameObject.tag == "Enemy") {
			Destroy(gameObject);
			GameObject.Find("Score").SendMessage("AddScore", 500);
		}
		if (col.gameObject.tag == "Ground") {
			Destroy(gameObject);
		}
	}
}