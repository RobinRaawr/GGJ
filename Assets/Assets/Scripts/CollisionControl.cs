using UnityEngine;
using System.Collections;

public class CollisionControl : MonoBehaviour {
	


	void OnCollisionEnter(Collision col)
	{
		if(col.gameObject.tag == "Enemy")
		{
			StartCoroutine(GameOver());
			GameControl.control.Player1.rigidbody.constraints = RigidbodyConstraints.None;
			GameControl.control.Player2.rigidbody.constraints = RigidbodyConstraints.None;
			GameControl.control.Rope.rigidbody.constraints = RigidbodyConstraints.None;
			//GameControl.control.Player1.hingeJoint.connectedBody = null;
			//GameControl.control.Player2.hingeJoint.connectedBody = null;
			Debug.Log("Enemy");
		}
	}

	public IEnumerator GameOver()
	{
		GameControl.control.Load ();
		if(GameControl.control.score > GameControl.control.highscore)
		{
			//ToDO: Naam laten invullen, naam wordt ook gesaved
			GameControl.control.Save();
		}
		yield return new WaitForSeconds (4);
		//Application.LoadLevel ("Gameover");
	}
}
