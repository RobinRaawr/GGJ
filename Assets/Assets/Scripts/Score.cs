using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class Score : MonoBehaviour {

    public static Score score;
    public bool notDead = true;
	Text currentScore;
	string scoreText = "Score: ";

	void Start () {
        score = this;
		currentScore = GetComponent<Text>();
	}

	void FixedUpdate()
	{
        if (notDead == true)
        {
            GameControl.control.score++;
        }
		currentScore.text = scoreText + GameControl.control.score;
	}
}
