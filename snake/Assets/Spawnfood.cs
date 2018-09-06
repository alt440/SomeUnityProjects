using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Spawnfood : MonoBehaviour {

    //Food prefabs
    public GameObject foodPrefab;
    public GameObject food_5;
    public GameObject headCloner;
    public GameObject shortener;
    public GameObject wall;
    public GameObject speeder;

    //List of these game objects
    List<GameObject> list = new List<GameObject>();

    //Autorizing shortener? And short frequency
    int countFood = 0;

    //For food to be spawned within borders
    public Transform borderTop; // thus, only need to call position w/ borderTop.position.
    public Transform borderBottom;
    public Transform borderLeft;
    public Transform borderRight;

	// Use this for initialization
	void Start () {
        list.Add(foodPrefab);
        list.Add(food_5);
        list.Add(headCloner);
        //list.Add(shortener);
        list.Add(wall);
        list.Add(speeder);
        //Spawn food every 4 seconds,starting in 3
        InvokeRepeating("Spawn", 3, 4);
	}
	
	// Update is called once per frame
	void Update () {

        if (countFood >= 5)
            list.Add(shortener);
	}

    void Spawn()
    {
        //x position btw left and right border
        int x = (int)Random.Range(borderLeft.position.x, borderRight.position.x);

        //y position
        int y = (int)Random.Range(borderBottom.position.y, borderTop.position.y);

        //Instantiate food at (x,y)
        int choiceOfFood;
        if (countFood >= 5)
            choiceOfFood = (int)(Random.value * 6);
        else
            choiceOfFood = (int)(Random.value * 5);


        Instantiate(list[choiceOfFood], new Vector2(x, y), Quaternion.identity);
        countFood++;
        if (choiceOfFood == 3||choiceOfFood ==1||choiceOfFood==0)
        {
            int a = (int)Random.Range(borderLeft.position.x, borderRight.position.x);
            int b = (int)Random.Range(borderBottom.position.y, borderTop.position.y);
            Instantiate(list[choiceOfFood], new Vector2(a, b), Quaternion.identity);

            int c = (int)Random.Range(borderLeft.position.x, borderRight.position.x);
            int d = (int)Random.Range(borderBottom.position.y, borderTop.position.y);
            Instantiate(list[choiceOfFood], new Vector2(c, d), Quaternion.identity);
        }
        
    }
}
