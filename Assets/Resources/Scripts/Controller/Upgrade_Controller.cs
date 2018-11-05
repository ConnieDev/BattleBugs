using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Upgrade_Controller : MonoBehaviour {
	Player_Stats playerData;
	public Text H, S, FR, FS, healthtxt, pointstxt;
	public float speed, health, fireRate, fireSpeed, points;
	// Use this for initialization
	void Start () {
		playerData = GameObject.FindGameObjectWithTag ("Player").GetComponent<Player_Stats> ();
		LoadStats ();
	}

	public void LoadStats(){
		points = 0;
		speed = 1;
		health = 0;
		fireRate = 1;
		fireSpeed = 1f;
		playerData.health = health + 10;
		UpdatePlayer ();
		UpdateText ();
	}

	public void UpdatePlayer(){
		playerData.speed = speed;
		playerData.fireRate = fireRate;
		playerData.fireSpeed = fireSpeed;
		playerData.UpdateStats ();
	}

	public void RestorHealth(){
		if (points > 0) {
			points -= 1;
			playerData.health += 2;
			UpdateHealthtxt ();
			UpdateText ();
		}
	}

	public void UpgradeSpeed(){
		if(speed < 10){
			if (points > 0) {
				points--;
				speed += 1f;
				UpdateText ();
				UpdatePlayer ();
			}
		}
	}
	public void UpgradeHealth(){
		if (health < 10) {
			if (points > 0) {
				points--;
		    	health += 1;
				playerData.health = health + 10;
				UpdateHealthtxt ();
				UpdateText ();
			}
		}
	}
	public void UpgradeFireRate(){
		if (fireRate < 10f) {
			if (points > 0) {
				points--;
				fireRate += 1f;
				UpdateText ();
				UpdatePlayer ();
			}
		}
	}
	public void UpgradeFireSpeed(){
		if (fireSpeed < 10) {
			if (points > 0) {
				points--;
				fireSpeed += 1f;
				UpdateText ();
				UpdatePlayer ();
			}
		}
	}

	public void UpdateHealthtxt(){
		healthtxt.text = "Health: " + playerData.health;
	}

	public void UpdateText(){
		pointstxt.text = "Points: " + points;
		FS.text = fireSpeed.ToString();
		FR.text = fireRate.ToString();
		H.text = health.ToString();
		S.text = speed.ToString();
	}


}
