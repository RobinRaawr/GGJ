using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class RestartGame : MonoBehaviour {
    Text currentScore;
	string scoreText = "Your highscore is: ";
	// Use this for initialization
	void Start () {
	    currentScore = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
        GameControl.control.Load();
        currentScore.text = scoreText + GameControl.control.highscore;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Application.LoadLevel("Level1");
        }

	}
}


