using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Wave_Controller : MonoBehaviour {

	public enum SpawnState{ SPAWNING, WAITING, COUNTING };
	public GameObject RedBugPrefab;
	public GameObject YellowBugPrefab;
	public GameObject GreenBugPrefab;
	public GameObject PurpleBugPrefab;
	public Upgrade_Controller UGC;
	int waveNum = 0;
	Text wavetxt;

	[System.Serializable]
	public class Wave{
		public string name;
		public GameObject redbug;
		public GameObject yellowbug;
		public GameObject greenbug;
		public GameObject purplebug;
		public GameObject godbug;
		public int count;
		public float rate;
	}

	public Wave[] waves;
	private int nextWave = 0;

	public Transform[] spawnPoints;

	public float timeBetweenWaves = 5f;
	private float waveCountDown;
	public int waveMultiplier;

	private float searchCountDown = 1f;

	private SpawnState state = SpawnState.COUNTING;

	void Start(){
		UGC = GetComponentInParent<Upgrade_Controller> ();
		wavetxt = GameObject.Find ("Wavetxt").GetComponent<Text>();
		UpdateWavetxt ();
		waveCountDown = timeBetweenWaves;
	}

	void Update(){

		if (state == SpawnState.WAITING) {
			if (!EnemyIsAlive ()) {
				WaveCompleted();
			} else {
				return;
			}
		}

		if (waveCountDown <= 0) {
			if (state != SpawnState.SPAWNING) {
				StartCoroutine (SpawnWave(waves[nextWave]));
			}
		} else {
			waveCountDown -= Time.deltaTime;
		}
	}

	void UpdateWavetxt(){
		waveNum++;
		wavetxt.text = "Wave: " + waveNum;
	}

	void WaveCompleted(){
		UpdateWavetxt ();
		state = SpawnState.COUNTING;
		waveCountDown = timeBetweenWaves;
		if (nextWave + 1 > waves.Length - 1) {
			for (int i = 0; i < waves.Length; i++) {
				waves [i].count = waveMultiplier * waveNum;
			}
			nextWave = 0;
			UGC.points++;
			UGC.UpdatePlayer ();
			UGC.UpdateText ();
		} else {
			nextWave++;
			UGC.points++;
			UGC.UpdatePlayer ();
			UGC.UpdateText ();
		}


	}

	bool EnemyIsAlive(){

		searchCountDown -= Time.deltaTime;
		if (searchCountDown <= 0f) {
			searchCountDown = 1f;
			if (GameObject.FindGameObjectWithTag ("Enemy") == null) {
				return false;
			}
		}
		return true;
	}

	IEnumerator SpawnWave(Wave _wave){
		Debug.Log ("spawn wave");
		state = SpawnState.SPAWNING;

		for(int i = 0; i < _wave.count; i++){
			if (waveNum < 50) {
				int ran = Random.Range (waveNum, waveNum + 50);
				if (ran <= 50) {
					SpawnEnemy (_wave.redbug, i);
				} else if (ran <= 75) {
					SpawnEnemy (_wave.yellowbug, i);
				} else if (ran <= 90) {
					SpawnEnemy (_wave.greenbug, i);
				} else {
					SpawnEnemy (_wave.purplebug, i);
				}
			} else {
				_wave.count = 1;
				SpawnEnemy (_wave.godbug, i);
			}

			yield return new WaitForSeconds(1f/_wave.rate);
		}

		state = SpawnState.WAITING;

		yield break;
	}

	void SpawnEnemy(GameObject _enemy, int count){
		Transform _sp = spawnPoints [count%2];
		GameObject enemy = ObjectPooler.GetPooledObject (_enemy);
		enemy.transform.position = _sp.position;
		enemy.transform.rotation = _sp.rotation;
		enemy.SetActive (true);
	}

}
