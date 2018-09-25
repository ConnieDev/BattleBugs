using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStarter : MonoBehaviour {
	public GameObject RedBugPrefab;
	public GameObject YellowBugPrefab;
	public GameObject GreenBugPrefab;
	public GameObject PurpleBugPrefab;
	public GameObject RedBugLaserPrefab;
	public GameObject YellowBugLaserPrefab;
	public GameObject GreenBugLaserPrefab;
	public GameObject PurpleBugLaserPrefab;
	public GameObject PlayerLaserPrefab;
	// Use this for initialization
	void Start () {
		ObjectPooler.CreateObjectPool (RedBugPrefab, 20);
		ObjectPooler.CreateObjectPool (YellowBugPrefab, 20);
		ObjectPooler.CreateObjectPool (GreenBugPrefab, 20);
		ObjectPooler.CreateObjectPool (PurpleBugPrefab, 20);
		ObjectPooler.CreateObjectPool (RedBugLaserPrefab, 20);
		ObjectPooler.CreateObjectPool (YellowBugLaserPrefab, 20);
		ObjectPooler.CreateObjectPool (GreenBugLaserPrefab, 20);
		ObjectPooler.CreateObjectPool (PurpleBugLaserPrefab, 20);
		ObjectPooler.CreateObjectPool (PlayerLaserPrefab, 50);
	}

}
