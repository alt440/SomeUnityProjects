using UnityEngine;
using System.Collections;

public class HighScoreText : MonoBehaviour {

    int highScore;
    int countSpeeders;
    int countHeadCloner;

	// Use this for initialization
	void Start () {
        highScore = PlayerPrefs.GetInt("highScore");
        countSpeeders = PlayerPrefs.GetInt("speeders");
        countHeadCloner = PlayerPrefs.GetInt("headCloner");
        GetComponent<GUIText>().text = "High score: " + highScore+"\nWith "+countSpeeders+" speeders and "+countHeadCloner+" head cloners.";
        PlayerPrefs.SetString("highScoreOfficial", highScore + " " + countSpeeders + " " + countHeadCloner);
        /*PlayerPrefs.DeleteKey("highScore");
        PlayerPrefs.DeleteKey("speeders");
        PlayerPrefs.DeleteKey("headCloner");*/
        PlayerPrefs.Save();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
