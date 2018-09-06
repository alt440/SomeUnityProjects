using UnityEngine;
using System.Collections;

public class HighScores : MonoBehaviour {



	// Use this for initialization
	void Start () {
        for (int i = 0; i < 10; i++)
        {
            GetComponent<GUIText>().text += (i + 1) + ". " + PlayerPrefs.GetString("highScoreOfficial" + i) + "\n";
        }

    }
	
	// Update is called once per frame
	void Update () {
        
        
    }
}
/*for (int i = 0; i<10; i++) {
     m_leaderBoardText+= "\t"+(i+1)+". "+ PlayerPrefs.GetInt(scoreKey+i)+ " - ";
     m_leaderBoardText+= " "+PlayerPrefs.GetString(scoreNameKey+i)+     " \n";
} */  