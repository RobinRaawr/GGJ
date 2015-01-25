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
			transform.localScale = new Vector3 (scale, transform.localScale.y, transform.localScale.z);
			transform.position = new Vector3 (transform.position.x, transform.position.y, player1.transform.position.z - (scale/2));
			if (scale >= 14)
			{
				ropebroke = true;
				rigidbody.useGravity = true;
				Destroy(player1.GetComponent<HingeJoint>());
				Destroy(player2.GetComponent<HingeJoint>());
				StartCoroutine(GetComponent<CollisionControl> ().GameOver ());
			}
			else
			{
			player1.hingeJoint.connectedBody = null;
			player1.hingeJoint.connectedBody = rigidbody;
			player2.hingeJoint.connectedBody = null;
			player2.hingeJoint.connectedBody = rigidbody;
			}
		}
	}
}
