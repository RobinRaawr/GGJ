using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Score : MonoBehaviour {

	Text currentScore;
	string scoreText = "Score: ";

	void Start () {
		currentScore = GetComponent<Text>();
	}

	void FixedUpdate()
	{
		GameControl.control.score++;
		currentScore.text = scoreText + GameControl.control.score;
	}
}
