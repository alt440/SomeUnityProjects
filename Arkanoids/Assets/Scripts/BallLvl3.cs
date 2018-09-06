using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BallLvl3 : MonoBehaviour {

    public Image image1;
    public Image image2;
    public Image image3;
    private int nbImages = 3;

    //Mvmt speed
    public float speed = 100;

    //Audio
    public AudioClip audio;

    //Prefab
    public BallLvl3 ball;

    //To access score
    private GameController ui;

    //Getting racket bigger
    public Racket racket;

    // Use this for initialization
    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = Vector2.up * speed;
        ball = GetComponent<BallLvl3>();

        GameObject gameObjectA = GameObject.FindWithTag("Text4Score");
        if (gameObjectA != null)
        {
            ui = gameObjectA.GetComponent<GameController>();

            ui.UpdateScore();
        }
        if (gameObjectA == null)
        {
            Debug.Log("Cant find gameObject in block script");
        }
        
    }

    void Update()
    {
        if (ui.score >= 1900)
            UnityEngine.SceneManagement.SceneManager.LoadScene(4);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.name == "racket")
        {
            //Calculate hit factor
            float x = hitFactor(transform.position, other.transform.position, other.collider.bounds.size.x);
            //Calculate direction, set length to 1
            Vector2 dir = new Vector2(x, 1).normalized;

            //Playing sound
            AudioSource.PlayClipAtPoint(audio, transform.position, 100.0f);
            //Set velocity with dir*speed
            GetComponent<Rigidbody2D>().velocity = dir * speed;
        }
        if (other.gameObject.tag == "Finish")
        {
            if (nbImages == 3)
                Destroy(image3);
            else if (nbImages == 2)
                Destroy(image2);
            else if (nbImages == 1)
                Destroy(image1);
            else
                UnityEngine.SceneManagement.SceneManager.LoadScene(1);
            //Remove one image, unless equals 0, which will load scene where says that user loses.
            nbImages--;

            gameObject.GetComponent<Rigidbody2D>().position = new Vector2(0.0f, -3.0f);
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0.0f, 0.0f);

            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0.0f, 1.0f) * speed;
        }
        if(other.gameObject.tag == "Bigger")
        {
            Destroy(other.gameObject);
            StartCoroutine(racket.Bigger());
        }

    }



    float hitFactor(Vector2 ballPos, Vector2 racketPos, float racketWidth)
    {
        return (ballPos.x - racketPos.x) / racketWidth;
        //this will determine how ball reflects on bracket. on the extremes the angle is bigger.
    }
}
