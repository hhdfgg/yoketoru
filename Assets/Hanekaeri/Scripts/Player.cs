using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
	public float MAX_SPEED = 6f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		//Debug.Log (Input.mousePosition);

		Vector3 mpos = Input.mousePosition;
		mpos.z = transform.position.z - Camera.main.transform.position.z;
		Vector3 target = Camera.main.ScreenToWorldPoint (mpos);

		// 自分からマウスへのベクトル(一発で目的地に到達する)
		//Vector3 dir = traget - transform.position;
		// dirの長さが最大速度より長かったら、長さを最大速度にする
		// そうでなければ、dirをそのまま使う

		// Unityには、そのための機能がある！！
		Vector3 newpos = Vector3.MoveTowards (
			transform.position,
			target,
			MAX_SPEED * Time.deltaTime);	// Time.deltaTimeで1回分の経過時間

		transform.position = newpos;
	}

	void OnTriggerEnter(Collider col){
		if(col.CompareTag("Teki")){
			Destroy (gameObject);
			GameManager.NextScene = "GameOver";
		}
	}
}
