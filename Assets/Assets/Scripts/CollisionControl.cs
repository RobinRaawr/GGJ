using UnityEngine;
using System.Collections;

public class CollisionControl : MonoBehaviour {
	
	void OnCollisionEnter(Collision col)
	{
		if(col.gameObject.tag == "Enemy")
		{
			StartCoroutine(GameOver());
		}
	}

	void Start()
	{
		StartCoroutine(GameOver());
	}

	public IEnumerator GameOver()
	{
		yield return new WaitForSeconds (4);
		//Application.LoadLevel ("Gameover");
		Debug.Log ("Gameover");
	}
}
