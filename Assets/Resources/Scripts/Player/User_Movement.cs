using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class User_Movement : MonoBehaviour {
	GameObject Controller;
	Text healthtxt;
	Player_Stats stats;
	public GameObject flash;
	private float speed;
    protected Joystick joystick;

	void Start () {
        joystick = GameObject.FindGameObjectWithTag("Joy1").GetComponent<FixedJoystick>();
		stats = GetComponent<Player_Stats> ();
		Controller = GameObject.FindGameObjectWithTag ("GameController");
		healthtxt = GameObject.Find ("Healthtxt").GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
		if (!Controller.GetComponent<Game_State_Controller> ().isPaused) {

            var rigidbody = GetComponent<Rigidbody2D>();
            if (this.transform.position.y >= -2.65 && this.transform.position.y <= 2.65)
            {
                rigidbody.velocity = new Vector3(joystick.Horizontal * speed, joystick.Vertical * speed, 0);
            }else if (this.transform.position.y < -2.65)
            {
                rigidbody.AddForce(new Vector2(0, .01f));
            }
            else if (this.transform.position.y > 2.65)
            {
                rigidbody.AddForce(new Vector2(0,-.01f));
            }
        }
	}

	public void updateSpeed (){
		speed = 2 + (GetComponent<Player_Stats> ().getSpeed ()*.2f);
	}
		
	void OnTriggerEnter2D(Collider2D col){
		if(col.tag == "Enemy_Weapon"){
			playerHit ();
		}
	}

	void playerHit(){
		stats.health--;
		healthtxt.text = "Health: " + stats.health;
		if (stats.health <= 0) {
			Controller.GetComponent<Game_State_Controller> ().GameOver ();
		} else {
			flash.SetActive (true);
			Invoke ("endFlash", .1f);
		}
	}

	void endFlash(){
		flash.SetActive (false);
	}
}
