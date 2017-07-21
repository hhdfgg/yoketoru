using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Game manager.
/// Oキーでゲームオーバー
/// Cキーでクリア
/// 両方のシーン切り替えが同時に発生しないようにする
/// </summary>

public class GameManager : MonoBehaviour {
	// 敵のプレハブ
	public GameObject prefTeki;
	// 敵を出現させる数
	public int TekiCount = 4;

	// アイテムのプレハブ
	public GameObject prefItem;
	// アイテムを出現させる数
	public int ItemCount = 10;

	// 次のシーンを記録する
	private static string _nextScene = "";

	// オーディオ追加
	private AudioSource sound01;

	public AudioClip [] SE;
	public AudioSource SEAudio;
	private static GameManager _instance;

	public static void PlaySE(int num){
		_instance.SEAudio.PlayOneShot (_instance.SE [num]);
	}


	// 次のシーンを指定する変数、空文字のときは何もしない
	public static string NextScene {
		get { return _nextScene; }
		set { 
			// 現在clearが設定されていないか、
			// あるいは、新しく空文字を設定したいときに設定を許可する
			if (    (_nextScene != "clear")
				||  (value == "")) 
			{
				_nextScene = value;
				Time.timeScale = 0;
			}
		}
	}



	void OnDestroy(){
		sound01.Stop();
	}


	// Use this for initialization
	void Start () {
		Time.timeScale = 1f;
		GameParams.SetScore (0);
		_nextScene = "";
		MoveBall.ClearBallCount ();


		_instance = this;

		/*
		// 敵を出現
		for (int i = 0; i < TekiCount; i++) {
			Instantiate (prefTeki);
		}
		// アイテムを出現
		for (int i = 0; i < ItemCount; i++) {
			Instantiate (prefItem);
		}
		*/

		// 変数にコンポーネント格納
		sound01 = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {

		//GameParams.AddScore (1);

		// Oキー
		if (Input.GetKeyDown (KeyCode.O)) {
			NextScene = "GameOver";
		}
		// Cキー
		else if (Input.GetKeyDown (KeyCode.C)){
			NextScene = "Clear";
			NextScene = "GameOver";
		}
		// Aキー
		else if (Input.GetKey (KeyCode.A)){
			GameParams.AddScore (50000);
		}




		// シーン切り替え処理
		if (NextScene.Length > 0){
			OnDestroy ();
			SceneManager.LoadSceneAsync (NextScene, LoadSceneMode.Additive);
			NextScene = "";
			enabled = false;
		}
	}
}