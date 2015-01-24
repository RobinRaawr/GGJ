using UnityEngine;
using System.Collections;

public class RopeStretching : MonoBehaviour {

	public Transform player1, player2;

	bool ropebroke = false;

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
		if(!ropebroke)
		{
			float scale = distanceBetweenPlayers ();
			transform.localScale = new Vector3 (transform.localScale.x, transform.localScale.y, scale);
			transform.position = new Vector3 (transform.position.x, transform.position.y, player1.transform.position.z - (scale/2));
			if (scale >= 14)
			{
				ropebroke = true;
				rigidbody.useGravity = true;
				//GetComponent<CollisionControl> ().GameOver ();
			}
		}
	}
}
