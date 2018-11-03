using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour {
    
    public GameObject enemy;
    public Transform[] spawnPoint;

	// Use this for initialization
	void Start () {

        for (int i = 0; i <spawnPoint.Length; i++)
        {
          GameObject newEnemy = Instantiate(enemy, spawnPoint[i].position, Quaternion.identity);
        }
	}
}
