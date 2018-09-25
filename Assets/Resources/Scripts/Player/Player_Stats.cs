using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Stats : MonoBehaviour {
	public float speed, health, fireRate, fireSpeed;

	public void UpdateStats(){
		GetComponent<User_Movement> ().updateSpeed ();
		GetComponentInChildren<Player_Aim> ().UpdateFireRate ();
	}

	public float getSpeed(){
		return speed;
	}
	public float getFireSpeed(){
		return fireSpeed;
	}
	public float getFireRate(){
		return fireRate;
	}
	public float getHealth(){
		return health;
	}
}
