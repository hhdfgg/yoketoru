using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillCheck : MonoBehaviour {
	//使わない場合、StartとUpdateは消してもよい

	// ぶつかった時の処理
	void OnTriggerEnter(Collider col) {
		Destroy (gameObject);
	}


	//マウスが重なった時の処理
	void OnMouseEnter(){
		//ぶつかったら消す
		//Destroy()が、ゲームオブジェクトを消す命令
		//gameObjectと書くと、自分のゲームオブジェクトのインスタンス(=実体)が入っている
		//Destroy(gameObject);

		// SetActove()は、VC#でのEnabledとVisibleをあわせたようなもの
		// falseにすると、そのゲームオブジェクトの動作が無効になって、非表示になる
		// Hierarchyに残ってはいるので、あとで、SetActive(true)で復活できる

		//gameObject.SetActive (false);

		//物理エンジンの時間を止める
		//Time.timeScale = 0f;
	}
}
