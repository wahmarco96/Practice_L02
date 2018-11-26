using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour {
    
    public GameObject[] enemyArmy;
    public GameObject[] enemyBoss;
    public Transform[] spawnPoint;

    float countingEnemyDeath;

    // Use this for initialization
    void Start () {
      SpawnCreep();
    }

    void Update(){
      SpawnBossCondition();
    }

    void SpawnCreep()
    {
        for (int i = 0; i < spawnPoint.Length; i++)
        {
            int m = Random.Range(0, enemyBoss.Length);
            Instantiate(enemyArmy[m], spawnPoint[i].position, Quaternion.identity);
        }
    }

    public void CountingEnemyDeath(float enemyDeathCount)
    {
        countingEnemyDeath = enemyDeathCount;
    }

    void SpawnBossCondition()
    {
        if (countingEnemyDeath >= 60)
        {
            SpawnBoss();
        }
    }

     void SpawnBoss()
    {
        int i = Random.Range(0, spawnPoint.Length);
        int e = Random.Range(0, enemyBoss.Length);
        Instantiate(enemyBoss[e], spawnPoint[i].position, Quaternion.identity);
    }
}
