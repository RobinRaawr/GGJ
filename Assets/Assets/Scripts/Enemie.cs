using UnityEngine;
using System.Collections;

public class Enemie : MonoBehaviour {

	public float moventspeed;
	public bool walking, flying, crawling;
	bool inScreen = false;

	void Start()
	{
		//rigidbody.velocity = new Vector3(-moventspeed, rigidbody.velocity.y, rigidbody.velocity.z);
        //rigidbody.AddForce(new Vector3(-moventspeed, 0, 0));
	}

    void FixedUpdate()
    {
        rigidbody.AddForce(new Vector3(-moventspeed, 0, 0));
    }

	void OnBecameVisible()
	{
		inScreen = true;
	}

	void OnBecameInvisible()
	{
		if (inScreen)
			Destroy (gameObject);
	}
}
