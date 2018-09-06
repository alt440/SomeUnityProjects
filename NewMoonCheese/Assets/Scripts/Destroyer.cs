using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Destroyer : MonoBehaviour {

    public static int score = 0;
    public Text theText;
    public GameObject gameOverPanel;
    public GameObject resume;
    public Button pause;
    public GameObject noSound;
    public Button sound;
    public AudioClip theSound;
    public AudioSource theSoundContainer;

    bool isPaused;
    bool isSound = true;

	// Use this for initialization
	void Start () {

        theText.text = "Score :" + score;
	}
	
	// Update is called once per frame
	void Update () {

        theText.text = "Score :" + score;

        if (Input.GetKeyDown("p"))
        {
            Pause();
            isPaused = true;
        }
        if (isPaused && Input.GetKeyDown("r"))
        {
            Resume();
            isPaused = false;
        }
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Ground")
        {
            score++;
            Destroy(other.gameObject);
        }
        else if (other.tag == "Player")
        {
            Time.timeScale = 0f;
            gameOverPanel.SetActive(true);

            if (!PlayerPrefs.HasKey("Score"))
            {
                PlayerPrefs.SetInt("Score", 0);
            }
            else
            {
                int highscore = PlayerPrefs.GetInt("Score");

                if (highscore < score)
                {
                    PlayerPrefs.SetInt("Score", score);
                }
            }
            score = 0;
            theText.text = "Score :"+score;
            //game over
        }
    }

    public void Resume()
    {
        Time.timeScale = 1f;
        resume.SetActive(false);
    }

    public void Pause()
    {
        Time.timeScale = 0f;
        resume.SetActive(true);
    }

    public void Sound()
    {
        if (isSound)
        {
            noSound.SetActive(true);
            theSoundContainer.Pause();
            isSound = false;
        }
        else
        {
            noSound.SetActive(false);
            theSoundContainer.Play();
            isSound = true;
        }
    }
}
