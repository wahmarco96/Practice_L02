using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpawnManager : MonoBehaviour {
   
    public GameObject[] enemyArmy;
    public GameObject[] enemyBoss;
    public Transform[] spawnPoint;
    float countingEnemyDeath;

    void Start()
    {
        SpawnCreep();
    }

    void Update()
    {
        SpawnBoss();
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

    void SpawnBoss()
    {
        if (countingEnemyDeath >= 60)
        {
            int i = Random.Range(0, spawnPoint.Length);
            int e = Random.Range(0, enemyBoss.Length);
            Instantiate(enemyBoss[e], spawnPoint[i].position, Quaternion.identity);
        }
    }

   /* IEnumerator  SpawnCreep2()
    {
        for (int i = 0; i < spawnPoint.Length; i++)
        {
            int m = Random.Range(0, enemyBoss.Length);
            Instantiate(enemyArmy[m], spawnPoint[i].position, Quaternion.identity);
        }
        yield return WaitUntil(SceneManager.LoadScene(2));
    }*/
}
