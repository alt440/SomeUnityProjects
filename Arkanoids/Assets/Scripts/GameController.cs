using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

    
    public int score;
	// Use this for initialization
	void Start () {

      
	}
	
	// Update is called once per frame
	public void AddScore (int score) {
        this.score += score;

	}

    public void UpdateScore()
    {
        GetComponent<GUIText>().text = "Score: " + score;
    }
}
