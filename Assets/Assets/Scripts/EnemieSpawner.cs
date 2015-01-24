using UnityEngine;
using System.Collections;

public class EnemieSpawner : MonoBehaviour {

	public float time = 2;
	public float timer;
    public float laneWidth;
	public float timerOffset = 1;
    public float spawnPoint;
	int lane;
	float enemyXPos;
	
	public GameObject[] enemies;

	void Start()
	{
		//enemyXPos = Camera.main.transform.position.x + (Camera.main.orthographicSize * Screen.width / Screen.height);
		Vector3 tempXpos = Camera.main.ViewportToWorldPoint (new Vector3(0, 1.1f, spawnPoint));
		enemyXPos = tempXpos.x;
		SetTimer ();
	}

	void Update () {
		timer = timer - Time.deltaTime;
		if(timer <= 0)
		{
			//Instanciate
			lane = getLane();
			float enemyZPos = lane * laneWidth;	//Lane * width baan
			Vector3 enemyPos = new Vector3(enemyXPos, 0, enemyZPos);
			GameObject enemyPrefab = getEnemy();
			GameObject spawnedEnemy = (GameObject)Instantiate(enemyPrefab, enemyPos, enemyPrefab.transform.rotation);
			SetTimer();
		}
	}

	void SetTimer()
	{
		timer = Random.Range (time - timerOffset, time + timerOffset);
	}

	GameObject getEnemy()
	{
		return enemies [Random.Range (0, enemies.Length - 1)];
	}

	int getLane()
	{
		return Random.Range (0, PlaneControl.control.lanes - 1);
	}
}
