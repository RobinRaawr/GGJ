﻿using UnityEngine;
using System.Collections;

public class EnemieSpawner : MonoBehaviour {

	public float time = 2;
	public float timer;
    public float laneWidth;
	public float timerOffset = 1;
    public float spawnPoint;
	int lane;
	float enemyXPos, enemyYPos;
	
	public GameObject[] enemies;

	void Start()
	{
		enemyXPos = 370;
		enemyYPos = 2f;
		SetTimer ();
	}

	void Update () {
		timer = timer - Time.deltaTime;
		if(timer <= 0)
		{
			//Instanciate
			lane = getLane();
			float enemyZPos = lane * laneWidth + (laneWidth/2);
			Vector3 enemyPos = new Vector3(enemyXPos, enemyYPos, enemyZPos);
			GameObject enemyPrefab = getEnemy();
			GameObject spawnedEnemy = (GameObject)Instantiate(enemyPrefab, enemyPos, enemyPrefab.transform.rotation);
			SetTimer();
			time -= 0.04f;
			timerOffset -= 0.01f;
		}
	}

	void SetTimer()
	{
		timer = Random.Range (time - timerOffset, time + timerOffset);
	}

	GameObject getEnemy()
	{
		return enemies [Random.Range (0, enemies.Length)];
	}

	int getLane()
	{
		return Random.Range (0, PlaneControl.control.lanes - 1);
	}
}
