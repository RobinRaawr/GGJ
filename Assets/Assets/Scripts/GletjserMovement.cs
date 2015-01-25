using UnityEngine;
using System.Collections;

public class GletjserMovement : MonoBehaviour {

    public float speed = 10f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        transform.position += new Vector3(speed, 0, 0);
	
	}
}
