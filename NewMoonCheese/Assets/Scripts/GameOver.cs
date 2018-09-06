using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameOver : MonoBehaviour {

    public Image whiteSquare;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
        if (Input.GetAxis("Vertical") == -1)
        {
            if(transform.position.y>-43)
            whiteSquare.transform.Translate(new Vector3(0, -8));
        }
        else if (Input.GetAxis("Vertical") == 1)
        {
            if (transform.position.y < -36)
            {
                whiteSquare.transform.Translate(new Vector3(0, 8));
            }
        }

	}
}
