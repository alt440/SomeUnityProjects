using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class Snake : MonoBehaviour
{

    //Current movement direction
    // (by default it moves to the right)
    Vector2 dir = Vector2.right;

    //Did snake eat smtg?
    bool ate = false;

    //Highscore
    public int highscore = 0;

    //Other scores to order high scores
    private int countHeadFood=0;
    private int countSpeeders=0;

    //List of scores
    [HideInInspector]
    public List<PlayerPrefs> highScores;
    

    //Tail prefab
    public GameObject tailPrefab;

    //Food_5 did?
    private bool Food_5 = false;

    //Head prefab
    public Snake head;
    [HideInInspector] public List<Snake> heads;

    [HideInInspector]
    public List<Transform> tail;

    //Speed
    private float moveSpeed=0.3f;

    // Use this for initialization
    void Start()
    {
        tail = new List<Transform>();
        heads.Add(head);
        //Move Snake every 300ms. Dont put in update bc snake would go too fast
        InvokeRepeating("Move", moveSpeed, moveSpeed);
    }

    // Update is called once per frame
    void Update()
    {

        //Detect key strokes
        if (Input.GetKey(KeyCode.RightArrow))
            dir = Vector2.right;
        else if (Input.GetKey(KeyCode.DownArrow))
            dir = -Vector2.up;
        else if (Input.GetKey(KeyCode.LeftArrow))
            dir = -Vector2.right;
        else if (Input.GetKey(KeyCode.UpArrow))
            dir = Vector2.up;
    }

    void Move()
    {
        //Save current position(gap will be here)
        Vector2 v = transform.position;

        //Movve head into new direction
        transform.Translate(dir);//Means add this vector to position

        if (ate)
        {
            //Load Prefab into the world
            GameObject g = (GameObject)Instantiate(tailPrefab, v, Quaternion.identity);

            //Keep track of it in our tail list
            tail.Insert(0, g.transform);

            //Reset the flag
            ate = false;
            
        }
        
        //Do we have tail?
        else if (tail.Count > 0)
        {
            //Move last tail element to where the head was
            tail.Last().position = v;

            //Add to front of list, remove from the back
            tail.Insert(0, tail.Last());
            tail.RemoveAt(tail.Count - 1);
            
        }
        Food_5 = false;
        /*We check if there is anything in the tail list, in which case we change the last tail
        element's position to the gap position (where the head was before). We also have
        to keep our list order, hence the Insert and RemoveAt calls at the end. They
        make sure that the last tail element is now the first element in the list, too.*/
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        //Food?
        if (coll.name.StartsWith("Food_1"))//bc called as Food(Clone)
        {
            //Get longer in next Move call
            ate = true;

            //Remove the food
            Destroy(coll.gameObject);
        }
        else if ((coll.name.StartsWith("Tail") || coll.name.StartsWith("Wall"))&&!Food_5)
        {
            for (int i = 0; i < heads.Count; i++) {
                highscore += heads.ElementAt<Snake>(i).tail.Capacity;
                Debug.Log("+" + heads.ElementAt<Snake>(i).tail.Capacity);
            }

            PlayerPrefs.SetInt("highScore", highscore);
            PlayerPrefs.Save();
            countSpeeders = 0;
            for (int i = 0; i < heads.Count; i++)
                countSpeeders +=(int) (-(heads.ElementAt<Snake>(i).moveSpeed / 0.05f) + 6); 

                //4 speeders : -0.1
            PlayerPrefs.SetInt("speeders", countSpeeders);
            PlayerPrefs.Save();

            countHeadFood = heads.Count-1;
            PlayerPrefs.SetInt("headCloner", countHeadFood);
            PlayerPrefs.Save();
            Application.LoadLevel(1);
            //ToDo 'You lose' screen
        }
        else if (coll.name.StartsWith("ShortenFood"))//Instead it will destroy the gameObject, so whole sequence of 1.
        {
            if (heads.Count > 1)
            {
                highscore += heads.ElementAt<Snake>(heads.Count-1).tail.Capacity;
                Destroy(heads.ElementAt(heads.Count-1));
                Destroy(coll.gameObject);
            }
            else
            {
                Application.LoadLevel(1);
            }
            /*highscore += 1;
            Transform a = tail.Last();
            tail.Remove(tail.Last());
            Destroy(a);*/
            
        }
        else if (coll.name.StartsWith("Food_5"))
        {
            //ate = true;
            for (int i = 0; i < 5; i++)
            {
                if (dir == Vector2.up)
                {
                    GameObject g = (GameObject)Instantiate(tailPrefab, new Vector3(transform.position.x, transform.position.y - i, 0), Quaternion.identity);
                    tail.Add(g.transform);
                }
                else if(dir == Vector2.right)
                {
                    GameObject g = (GameObject)Instantiate(tailPrefab, new Vector3(transform.position.x-i, transform.position.y, 0), Quaternion.identity);
                    tail.Add(g.transform);
                }
                else if(dir == -Vector2.right)
                {
                    GameObject g = (GameObject)Instantiate(tailPrefab, new Vector3(transform.position.x+i, transform.position.y, 0), Quaternion.identity);
                    tail.Add(g.transform);
                }
                else if (dir == -Vector2.up)
                {
                    GameObject g = (GameObject)Instantiate(tailPrefab, new Vector3(transform.position.x, transform.position.y + i, 0), Quaternion.identity);
                    tail.Add(g.transform);
                }
            }

            Destroy(coll.gameObject);
            Food_5 = true;

            //count++;
        }
        else if (coll.name.StartsWith("HeadCloner"))
        {
            
            Destroy(coll.gameObject);
            Snake head2 = (Snake)Instantiate(head, new Vector3(transform.position.x - 5, transform.position.y-5), Quaternion.identity);
            
            head2.Update();
            heads.Add((Snake)head2);
            
        }
        else if (coll.name.StartsWith("Speeder"))
        {
            
            Destroy(coll.gameObject);
            moveSpeed -= 0.05f;
            ++countSpeeders;
            CancelInvoke();
            InvokeRepeating("Move", moveSpeed, moveSpeed);
            
        }
    }
}