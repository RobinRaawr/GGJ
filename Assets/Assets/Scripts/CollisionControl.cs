using UnityEngine;
using System.Collections;

public class CollisionControl : MonoBehaviour {

	void OnCollisionEnter(Collision col)
	{
		if(col.gameObject.tag == "Enemy")
		{
            Score.score.notDead = false;
			StartCoroutine(GameOver());
			GameControl.control.Player1.rigidbody.constraints = RigidbodyConstraints.None;
			GameControl.control.Player2.rigidbody.constraints = RigidbodyConstraints.None;
			GameControl.control.Rope.rigidbody.constraints = RigidbodyConstraints.None;
            
		}
	}

	public IEnumerator GameOver()
	{
        audio.Play();
		GameControl.control.Load ();
		if(GameControl.control.score > GameControl.control.highscore)
		{
			//ToDO: Naam laten invullen, naam wordt ook gesaved
			GameControl.control.Save();
		}
		yield return new WaitForSeconds (2);
		Application.LoadLevel ("GameOver");
	}
}
