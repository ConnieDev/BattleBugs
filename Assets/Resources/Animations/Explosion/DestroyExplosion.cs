using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyExplosion : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Invoke ("End", .5f);
	}
	
	void End(){
		Destroy (gameObject);
	}
}
