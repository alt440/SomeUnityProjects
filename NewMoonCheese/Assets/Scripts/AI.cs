using UnityEngine;
using System.Collections;

public class AI : MonoBehaviour {

    public float speed;

    PlayerMoveScene2 player;

    float n=1;

	// Use this for initialization
	void Start () {
        GetComponent<Rigidbody>().velocity = new Vector3(speed, 0);

        GameObject zePlayer = GameObject.FindWithTag("Player");
        if (zePlayer != null)
        {
            player = zePlayer.GetComponent<PlayerMoveScene2>();
        }
    }
	
	// Update is called once per frame
	void Update () {

        
	}

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Ground")
        {
            GetComponent<Rigidbody>().velocity = Vector3.zero;
            GetComponent<Rigidbody>().velocity = new Vector3(speed * Mathf.Pow(-1, n), 0);
            n++;
        }
        else if (GetComponent<BoxCollider>().contactOffset != 0)
        {
            Destroy(gameObject);
        }
        else if (GetComponent<SphereCollider>().contactOffset != 0 && other.tag == "Player")
        {
            Destroy(player);
        }
        
        
    }
}
