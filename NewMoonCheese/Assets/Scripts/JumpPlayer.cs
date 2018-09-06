using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class JumpPlayer : MonoBehaviour {

    public float speed;
    public float speedSides;
    

    
    float currentSpeedX;
    float currentSpeedY;

	// Use this for initialization
	void Start () {
        GetComponent<Rigidbody>().position = new Vector3(0, 0, 0);
        GetComponent<Rigidbody>().velocity = Vector3.zero;
        
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetAxis("Horizontal")>0.25)
        {
            
           GetComponent<Rigidbody>().velocity += new Vector3(speedSides, 0)*Time.deltaTime;
            
        }
        else if (Input.GetAxis("Horizontal")<-0.25)
        {
            
           GetComponent<Rigidbody>().velocity += new Vector3(-speedSides, 0)*Time.deltaTime;
            
        }
        currentSpeedX = GetComponent<Rigidbody>().velocity.x;
        currentSpeedY = GetComponent<Rigidbody>().velocity.y;
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Ground")
        {
            if (gameObject.GetComponent<SphereCollider>().transform.position.y > other.GetComponent<BoxCollider>().transform.position.y)
            {
                GetComponent<Rigidbody>().velocity = new Vector3(currentSpeedX, speed);
                
                
            }
            else
            {
                GetComponent<Rigidbody>().velocity = new Vector3(currentSpeedX, currentSpeedY);
            }
            
            /*GetComponent<Rigidbody>().velocity = new Vector3(0, speed);
            if (goingLeft)
            {
                GetComponent<Rigidbody>().velocity += new Vector3(-1, 0);
            }
            else if (goingRight)
            {
                GetComponent<Rigidbody>().velocity += new Vector3(1, 0);
            }*/
        }
    }
}
