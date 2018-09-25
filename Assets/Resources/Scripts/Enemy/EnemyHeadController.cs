using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHeadController : MonoBehaviour {
	EnemyData data;
	private GameObject LaserPrefab;
	GameObject Controller;
	GameObject target;
	Vector3 laserOffset = new Vector3 (0, 0.5f, 0);

	private float fireDelay;
	float cooldownTimer = 0;

	void Start () {
		Controller = GameObject.FindGameObjectWithTag ("GameController");
		target = GameObject.FindGameObjectWithTag ("Player");
		data = GetComponentInParent<EnemyData> ();
		fireDelay = data.fireDelay;
		LaserPrefab = data.laser;
	}

	// Update is called once per frame
	void Update () {
		if (!Controller.GetComponent<Game_State_Controller> ().isPaused) {
			
			Vector3 t = target.transform.position;
			transform.rotation = Quaternion.Euler (0, 0, Mathf.Atan2 (t.y - transform.position.y, t.x - transform.position.x) * Mathf.Rad2Deg - 90);
			cooldownTimer -= Time.deltaTime;
		
			if (cooldownTimer <= 0) {
				if (GetComponentInParent<EnemyBodyController> ().atk) {
					if (this.name == "PurpleBug(Clone)") {
						BossShoot ();
					} else {
						shoot ();
					}
				}
				cooldownTimer = fireDelay; 
			}
		}
	}

	void shoot(){
		Vector3 offset = transform.rotation * laserOffset;

		GameObject laser = ObjectPooler.GetPooledObject (LaserPrefab);
		laser.transform.position = transform.position + offset;
		laser.transform.rotation = transform.rotation;
		laser.SetActive (true);
	}

	void BossShoot(){

	}
}
