using UnityEngine;
using System.Collections;

public class RopeStretching : MonoBehaviour {

	public GameObject player1, player2;
	public float distanceBetweenPlayers;

	void Start()
	{
		distanceBetweenPlayers = player1.transform.position.z - player2.transform.position.z;
	}

	//void 
}
