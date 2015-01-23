using UnityEngine;
using System.Collections;

public class EnemieSpawner : MonoBehaviour {

	public float time = 2;
	public float timer;
	public float timerOffset = 1;
	int lane;
	float enemyXPos;
	
	public GameObject[] enemies;

	void Start()
	{
		enemyXPos = Camera.main.transform.position.x + (Camera.main.pixelWidth / 2);
		SetTimer ();
	}

	void Update () {
		timer = timer - Time.deltaTime;
		if(timer <= 0)
		{
			//Instanciate
			lane = getLane();
			float enemyYPos = lane;
			Vector3 enemyPos = new Vector3(enemyXPos, enemyYPos, 0);
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
		return Random.Range (0, 5);
	}
}
