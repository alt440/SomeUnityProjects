using UnityEngine;
using System.Collections;

public class GoTo : MonoBehaviour {

	// Use this for initialization
	public void LoadScene(int value)
    {
        Application.LoadLevel(value);
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
