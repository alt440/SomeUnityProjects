using UnityEngine;
using System.Collections;

public class Racket : MonoBehaviour {
    //Mvmt speed
    public float speed = 130;

    // Update is called once per frame
    void FixedUpdate () {

        float h = Input.GetAxisRaw("Horizontal"); //-1 for left, 1 for right

        GetComponent<Rigidbody2D>().velocity = Vector2.right * h * speed;

	}

    public IEnumerator Bigger()
    {
        transform.localScale += new Vector3(0.2f, 0);
        yield return new WaitForSeconds(20);
        transform.localScale -= new Vector3(0.2f, 0); 
    }
}
