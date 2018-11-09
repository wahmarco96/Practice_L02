using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour {
    
    public GameObject enemy;
    public GameObject enemyBoss;
    public Transform[] spawnPoint;

    float enemyDeath;

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
            Instantiate(enemy, spawnPoint[i].position, Quaternion.identity);
        }
    }

    public void CountingEnemyDeath(float deathCount)
    {
        enemyDeath = deathCount;
    }

    void SpawnBossCondition()
    {
        if (enemyDeath >= 60)
        {
            SpawnBoss();
        }
    }

     void SpawnBoss()
    {
        int i = Random.Range(0, spawnPoint.Length);
        Instantiate(enemyBoss, spawnPoint[i].position, Quaternion.identity);
    }
}
