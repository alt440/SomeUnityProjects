using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BlockSpawn : MonoBehaviour {

    public GameObject[] blocks;
    
   
    //ref. obj.

	// Use this for initialization
	void Start () {
        
        StartCoroutine(SpawnRandomObstacle());
	}
	
	// Update is called once per frame
	void Update () {
        
    }

    IEnumerator SpawnRandomObstacle()
    {
        while (true)
        {
            yield return new WaitForSeconds(5);
            
            Instantiate(blocks[(int)(Random.value * 2.5)], new Vector3(Random.Range(-11f, 11f), 5), Quaternion.identity);
            
        }
        
    }
}
