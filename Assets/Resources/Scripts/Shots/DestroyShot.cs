using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DestroyShot : MonoBehaviour {
	public GameObject Enemy;
	public float BN;
	void Start(){
		if (tag == "Enemy_Weapon") {
			BN = Enemy.GetComponent<EnemyData> ().laserBounceNum;
		} else {
			BN = 2;
		}
	}

	void OnBecameInvisible(){
		Disable ();
	}

	void OnTriggerEnter2D(Collider2D col){
		if (this.tag == "Weapon") {
			if (col.tag == "Enemy" || col.tag == "Enemy_Weapon" || col.tag == "VWall" || col.tag == "HWall") {
				if (col.tag == "VWall" || col.tag == "HWall") {
					if (BN <= 0) {
						Disable ();
					} else {
						Bounce (col.tag);
					}
				} else {
					Disable ();
				}
			}
		} else if(tag == "Enemy_Weapon"){
			if(col.tag == "Player" || col.tag == "Weapon" || col.tag == "VWall" || col.tag == "HWall"){
				if (col.tag == "VWall" || col.tag == "HWall") {
					if (BN <= 0) {
						Disable ();
					} else {
						Bounce (col.tag);
					}
				} else {
					Disable ();
				}
			}
		}

	}

	void Bounce(string w){
		BN--;
		if (w == "VWall") {
			this.transform.rotation = Quaternion.Inverse (this.transform.rotation);
		} else {
			float z;
			if (this.transform.rotation.eulerAngles.z > 0 && this.transform.rotation.eulerAngles.z < 180) {
				z = 180 - this.transform.rotation.eulerAngles.z;
			} else {
				z = -180 - this.transform.rotation.eulerAngles.z;
			}
			Quaternion newRotation = Quaternion.Euler (0, 0, z);
			this.transform.rotation = newRotation;
		}
	}

	void Disable(){
		if (tag == "Enemy_Weapon") {
			BN = Enemy.GetComponent<EnemyData> ().laserBounceNum;
		} else {
			BN = 2;
		}
		gameObject.SetActive (false);
	}
}
