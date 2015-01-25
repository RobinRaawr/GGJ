using UnityEngine;
using System.Collections;

public class StartScherm: MonoBehaviour
{
    public KeyCode startKey;
    public KeyCode creditsKey;
    public string startLevel;
    public string creditsLevel;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        StartGame();
        StartCredits();
    }

    void StartCredits()
    {
        if (!Input.GetKeyDown(creditsKey))
        {
            return;
        }
        Application.LoadLevel(creditsLevel);
    }
    void StartGame()
    {
        if (!Input.anyKey)
        {
            return;
        }
        Application.LoadLevel(startLevel);
    }
}
