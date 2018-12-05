using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Enemy : MonoBehaviour {
    NavMeshAgent agent;
    private Player player;
    public float maxHealth;
    float currentHealth;
    public GameObject healthCanvas;
    public Image currentHealthBar;
    bool playerInRange;
    Vector3 originPos;

    public SpawnManager spawnCounting;
    float enemyDeathCount;

    protected bool bossIsDead = false;
    public float gameLevel;
    

    protected virtual void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        spawnCounting = GameObject.FindGameObjectWithTag("SpawnManager").GetComponent<SpawnManager>();
        agent = GetComponent<NavMeshAgent>();
        healthCanvas.SetActive(false);
        currentHealth = maxHealth;
        originPos = this.transform.position;

        enemyDeathCount = 0f;
        gameLevel = GameManager.Instance.level;
    }

    // Update is called once per frame
    public virtual void Update()
    {
        StartCoroutine(ChasePlayer());
        NoticePlayerInRange();
        IsDead();
    }

    protected IEnumerator ChasePlayer()
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

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        CheckCurrentHealth();
        IsDead();
    }


    void CheckCurrentHealth()
    {

        healthCanvas.SetActive(true);
        currentHealthBar.fillAmount = currentHealth / maxHealth;
    }

    void IsDead()
    {
        if (maxHealth < 1f)
        {
            //booom.Play();
            Destroy(this.gameObject);
            enemyDeathCount += 1;
            spawnCounting.CountingEnemyDeath(enemyDeathCount);
            bossIsDead = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Sword")
        {
            maxHealth -= player.damage;
            //Destroy(gameObject);
        }

        else if (other.gameObject.tag == "Ultimate")
        {
            Destroy(gameObject);
        }

    }

}
