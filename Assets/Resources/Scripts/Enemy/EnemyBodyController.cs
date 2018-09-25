using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBodyController : MonoBehaviour {
	EnemyData data;
	float speed, health;
	public bool atk = false;
	public GameObject player;
	public Transform[] wayPoints;
	public SpriteRenderer rend;
	public Transform target;

	public GameObject explosion;
	// Use this for initialization
	void Start () {
		rend = GetComponentInChildren<SpriteRenderer> ();
		player = GameObject.FindGameObjectWithTag ("Player");
		data = GetComponentInParent<EnemyData>();
		speed = data.speed;
		health = data.health;
		FindPath ();
	}

	void OnEnable(){
		atk = false;
		FindPath ();
	}

	void FindPath(){
		
		if (Vector3.Distance (transform.position, wayPoints [0].position) < Vector3.Distance (transform.position, wayPoints [3].position)) {
			target = wayPoints [0];
		} else {
			target = wayPoints [3];
		}

	}
	
	// Update is called once per frame
	void Update () {
		if (!atk) {
			transform.LookAt (target);
			if (Vector3.Distance (transform.position, target.position) > .5) {
				transform.position += transform.forward * speed * Time.deltaTime;
			} else {
				if (target == wayPoints [0]) {
					target = wayPoints [1];
				} else if (target == wayPoints [1]) {
					target = wayPoints [2];
				} else if (target == wayPoints [3]) {
					target = wayPoints [4];
				} else if (target == wayPoints [4]) {
					target = wayPoints [5];
				} else {
					atk = true;
				}
			}
		} else {
			transform.LookAt (player.transform);
			if(Vector3.Distance(transform.position, player.transform.position) > 2){
				transform.position += transform.forward * speed * Time.deltaTime;
			}
		}
	}

	void OnTriggerEnter2D(Collider2D col){
		
		if (col.tag == "Weapon") {
			Hit ();
			if (health <= 0) {
				Disable ();
			}
		}
	}

	void Hit(){
		rend.enabled = false;
		Invoke ("EndFlash", .1f);
		health--;
	}

	void EndFlash(){
		rend.enabled = true;
	}

	void Disable(){
		health = data.health;
		Instantiate (explosion, transform.position,Quaternion.identity);
		gameObject.SetActive (false);
	}
}
