using UnityEngine;
using System.Collections;

public class Enemie : MonoBehaviour {

	public float moventspeed;
	bool inScreen = false;

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
