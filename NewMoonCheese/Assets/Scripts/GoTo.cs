using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GoTo : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void lvl(int thelvl)
    {
        SceneManager.LoadScene(thelvl);
        Time.timeScale = 1f;
    }

}
