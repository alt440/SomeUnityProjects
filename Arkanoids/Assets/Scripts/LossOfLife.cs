using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LossOfLife : MonoBehaviour {
    
    public Image image1;
    public Image image2;
    public Image image3;
    private int nbImages;

    public Ball ball;


	// Use this for initialization
	void Start () {
        nbImages = 3;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ball"))
        {
             if (nbImages == 3)
                 Destroy(image3);
             else if (nbImages == 2)
                 Destroy(image2);
             else if (nbImages == 1)
                 Destroy(image1);
             //Remove one image, unless equals 0, which will load scene where says that user loses.
             nbImages--;

            other.gameObject.GetComponent<Rigidbody2D>().position = new Vector2(0.0f, 0.0f);
            //other.gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.up * ball.speed;
        }
    }
}
