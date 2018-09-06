using UnityEngine;
using System.Collections;

public class Block : MonoBehaviour {

    
    
    private GameController ui;

    void Start()
    {
        
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

   /* void UpdateScore()
    {
        ui.GetComponent<GUIText>().text = "Score: " + score;
    }*/

	void OnCollisionEnter2D(Collision2D other)
    {
        //destroy block + play sound
        

        if (gameObject.tag == "Red")
        {
            ui.AddScore(15);
            ui.UpdateScore();
        }
        else if (gameObject.tag == "Green")
        {
            ui.AddScore(20);
            ui.UpdateScore();
        }
        else if (gameObject.tag == "Blue")
        {
            ui.AddScore(25);
            ui.UpdateScore();
            
        }
        else if (gameObject.tag == "Yellow")
        {
            ui.AddScore(30);
            ui.UpdateScore();
            
        }
        else if (gameObject.tag == "Pink")
        {
            ui.AddScore(35);
            ui.UpdateScore();
            
        }
        Destroy(gameObject);
    }

        
}
