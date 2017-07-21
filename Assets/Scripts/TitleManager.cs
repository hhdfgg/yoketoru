using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleManager : MonoBehaviour {

	// タイトルクリック時の音追加
	//public AudioClip sound1;

	// オーディオ追加
	public AudioClip se;

	void Start() {
		GameParams.DrawScore ();
		/*// タイトルクリック時の音の変数
		sound1 = GetComponent<AudioSource> ();*/
	}
		
	// Update is called once per frame
	void Update () {

		// タイトルクリック時
		if(Input.GetMouseButtonDown(0)) {
			GetComponent<AudioSource> ().PlayOneShot (se);
		}

		// fire1キーが押されたら、Gameシーンに切り替え
		if (Input.GetButtonDown ("Fire1")) {
			SceneManager.LoadSceneAsync ("Game");
		}



	}
}
