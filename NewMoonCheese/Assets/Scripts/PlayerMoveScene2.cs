using UnityEngine;
using System.Collections;

public class PlayerMoveScene2 : MonoBehaviour {

    public float speed;
    public float speedJump;
    public Transform groundCheck;

	// Use this for initialization
	void Start () {

        
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        Physics.gravity = new Vector3(0, -100);
        float input = Input.GetAxis("Horizontal");
        GetComponent<Rigidbody>().velocity = new Vector3(speed * input, 0);

        bool grounded = Physics.Linecast(transform.position, new Vector3(0,-20), LayerMask.NameToLayer("Ground"));
        

        if (Input.GetKeyDown(KeyCode.UpArrow) && grounded)
        {
            GetComponent<Rigidbody>().velocity += new Vector3(0, speedJump);

        }
       
            


    }
}
