using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour {
    
    public GameObject enemy;
    //public enum spawnPos {spawn1,spawn2};
    //  public spawnPos[] allPos;
    public Transform[] spawnPoint;

	// Use this for initialization
	void Start () {

        for (int i = 0; i < 5; i++)
        {
            Instantiate(enemy, spawnPoint[i].position, Quaternion.identity);
        }

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
