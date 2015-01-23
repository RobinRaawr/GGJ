using UnityEngine;
using System.Collections;

public class Enemie : MonoBehaviour {

	public float moventspeed;
	public bool walking, flying, crawling;

	GameObject g = this.gameObject;
	Rigidbody2D r = this.rigidbody2D;
}
