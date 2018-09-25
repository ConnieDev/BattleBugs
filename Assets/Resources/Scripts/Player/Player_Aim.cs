using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Aim : MonoBehaviour {
	public GameObject LaserPrefab;
	GameObject Controller;

	Vector3 laserOffset = new Vector3 (0, 0.5f, 0);

    protected Joystick joystick;

    public float fireRate;
	float cooldownTimer = 0;
	// Use this for initialization
	void Start () {
        joystick = GameObject.FindGameObjectWithTag("Joy2").GetComponent<FixedJoystick>();
        Controller = GameObject.FindGameObjectWithTag ("GameController");
	}
	
	// Update is called once per frame
	void Update () {
		if (!Controller.GetComponent<Game_State_Controller> ().isPaused) {
            Vector3 lookvec = new Vector3(joystick.Horizontal * 10, joystick.Vertical * 10, 100000);
            if (lookvec.x != 0 && lookvec.y != 0)
            {
                transform.rotation = Quaternion.LookRotation(lookvec, Vector3.back);
            }
			cooldownTimer -= Time.deltaTime;

			if (cooldownTimer <= 0 ) {
				shoot ();
				cooldownTimer = 1/fireRate; 
			}
		}
	}

	public void UpdateFireRate(){
		fireRate = GetComponentInParent<Player_Stats>().getFireRate()*2;
	}

	void shoot(){
		Vector3 offset = transform.rotation * laserOffset;

		GameObject laser = ObjectPooler.GetPooledObject (LaserPrefab);
		laser.transform.position = transform.position + offset;
		laser.transform.rotation = transform.rotation;
		laser.SetActive (true);
	}
}
