﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CallGameScene : MonoBehaviour {

	IEnumerator Start () {
		yield return new WaitForSeconds(2);
		Application.LoadLevel("GameScene");
	}
}
