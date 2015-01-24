using UnityEngine;
using System.Collections;

public class RopeStretching : MonoBehaviour {

	public Transform player1, player2;

	void Start()
	{
		StretchRope ();
	}

	float distanceBetweenPlayers()
	{
		return player1.transform.position.z - player2.transform.position.z;
	}

	public void StretchRope()
	{
		float scale = distanceBetweenPlayers ();
		transform.localScale = new Vector3 (transform.localScale.x, transform.localScale.y, scale);
		transform.position = new Vector3 (transform.position.x, transform.position.y, player1.transform.position.z - (scale/2));
	}
}
