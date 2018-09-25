using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShot : MonoBehaviour {
	GameObject Controller;
	public GameObject Enemy;
	public float speed;
	void Start(){
		Controller = GameObject.FindGameObjectWithTag ("GameController");
		speed = Enemy.GetComponent<EnemyData> ().laserSpeed;
	}

	void Update () {
		if(!Controller.GetComponent<Game_State_Controller>().isPaused){
			transform.Translate (0, speed, 0);
		}
	}
}
