using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour {
	public GameObject INFO;
	public void LoadGame_View(){
		SceneManager.LoadScene ("Game_View");
	}

	public void Toggle_INFO(){
		if (INFO.activeInHierarchy) {
			INFO.SetActive (false);
		} else {
			INFO.SetActive (true);
		}
	}

	public void QuitGame(){
		Application.Quit ();
	}
}
