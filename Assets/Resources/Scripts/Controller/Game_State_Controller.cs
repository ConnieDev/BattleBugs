using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game_State_Controller : MonoBehaviour {
	public GameObject PauseScreen;
	public GameObject UpgradeScreen;
	public GameObject GameOverScreen;
	Wave_Controller wave;
	public bool isPaused;
	// Use this for initialization
	void Start () {
		isPaused = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void TogglePaused(){
		if (isPaused) {
			PauseScreen.SetActive (false);
			Time.timeScale = 1;
			isPaused = false;
		} else {
			PauseScreen.SetActive (true);
			Time.timeScale = 0;
			isPaused = true;
		}
	}

	public void ToggleUpgrade(){
		if (PauseScreen.activeInHierarchy) {
			PauseScreen.SetActive (false);
			UpgradeScreen.SetActive (true);
		}else{
			if (isPaused) {
				UpgradeScreen.SetActive (false);
				Time.timeScale = 1;
				isPaused = false;
			} else {
				UpgradeScreen.SetActive (true);
				Time.timeScale = 0;
				isPaused = true;
			}
		}
	}

	public void GameOver(){
		isPaused = true;
		Time.timeScale = 0;
		GameOverScreen.SetActive (true);
	}

	public void LoadMainMenu(){
		Time.timeScale = 1;
		ObjectPooler.objectPools.Clear ();
		SceneManager.LoadScene ("Menu_View");
	}
	public void LoadGameView(){
		Time.timeScale = 1;
		ObjectPooler.objectPools.Clear ();
		SceneManager.LoadScene ("Game_View");
	}
}
