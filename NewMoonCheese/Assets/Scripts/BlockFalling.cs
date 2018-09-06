using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BlockFalling : MonoBehaviour {

    public float speed;
    public bool jumpedOn;
    public static int score = 0;
    


    // Use this for initialization
    void Start () {
        GetComponent<Rigidbody>().velocity = new Vector3(0, -speed);
        
    }
	
	// Update is called once per frame
	void Update () {

        
    }

    
}
