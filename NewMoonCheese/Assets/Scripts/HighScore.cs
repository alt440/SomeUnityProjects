using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HighScore : MonoBehaviour {

    public Text highScore;
	// Use this for initialization
	void Start () {

        if (!PlayerPrefs.HasKey("Score"))
            highScore.text = "High score: 0";
        else
            highScore.text = "High score: " + PlayerPrefs.GetInt("Score");
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
