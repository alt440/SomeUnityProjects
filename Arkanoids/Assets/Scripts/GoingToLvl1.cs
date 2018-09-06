using UnityEngine;
using System.Collections;

public class GoingToLvl1 : MonoBehaviour {

    public void LoadScene(int nb)
    {
        Application.LoadLevel(nb);
    }



   /* public void OnMouseDown()
    {
        //Application.LoadLevel("Scenes/Arkanoid Lvl1");
        //UnityEngine.SceneManagement.SceneManager.LoadScene("Scenes/Arkanoid Lvl1");
    }*/
}
