using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShot : MonoBehaviour {
	GameObject Controller;
	private float speed;
	private Player_Stats stats;

	void Start(){
		Controller = GameObject.FindGameObjectWithTag ("GameController");
		stats = GameObject.FindGameObjectWithTag ("Player").GetComponent<Player_Stats> ();
		speed = .05f + (stats.getFireSpeed ()*.015f);
	}

	void OnEnable(){
		stats = GameObject.FindGameObjectWithTag ("Player").GetComponent<Player_Stats> ();
		speed = .05f + (stats.getFireSpeed ()*.015f);
	}

	void Update () {
		if (!Controller.GetComponent<Game_State_Controller> ().isPaused) {
			
			transform.Translate (0, speed, 0);
		}
	}
}
