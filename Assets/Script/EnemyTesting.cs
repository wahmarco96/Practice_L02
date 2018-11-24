using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class EnemyTesting : MonoBehaviour
{

    NavMeshAgent agent;
    private Player player;
    public float maxHealth;
    public float currentHealth;
    public Image currentHealthBar;
    public bool playerInRange;
    Vector3 originPos;

    public SpawnPoint spawnCounting;
    public float enemyDeathCount;

    // Use this for initialization
    protected virtual void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        agent = GetComponent<NavMeshAgent>();
        currentHealth = maxHealth;
        originPos = this.transform.position;

        enemyDeathCount = 0f;
    }

    // Update is called once per frame
    public virtual void Update()
    {
        StartCoroutine(CheckPlayerPos());
        NoticePlayerInRange();

    }
    
    protected IEnumerator CheckPlayerPos()
    {
        if (playerInRange == true)
        {
            agent.SetDestination(player.transform.position);
            yield return new WaitForSeconds(1);
        }

        else
        {
            agent.SetDestination(originPos);
        }
    }

    protected void NoticePlayerInRange()
    {
        if (Vector3.Distance(player.transform.position, this.transform.position) < 60f)
        {
            playerInRange = true;
        }
        else
        {
            playerInRange = false;
        }
    }

    public void TakeDamage( int damage )
    {
        currentHealth -= damage;
        CheckCurrentHealth();
        IsDead();
    }
    

    void CheckCurrentHealth()
    {
        currentHealthBar.fillAmount = currentHealth / maxHealth;
    }

    void IsDead()
    {
        if (currentHealth < 1f)
        {
            Destroy(this.gameObject);
            enemyDeathCount += 1;
            spawnCounting.CountingEnemyDeath(enemyDeathCount);
        }
    }
}
