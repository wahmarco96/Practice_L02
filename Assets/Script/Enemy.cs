using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{

    NavMeshAgent agent;
    private Player player;
    float maxHealth = 5f;
    public float currentHealth;
    public Image currentHealthBar;
    public bool playerInRange;
    Vector3 originPos;

    // Use this for initialization
    void Start()
    {
        this.player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        agent = GetComponent<NavMeshAgent>();
        currentHealth = maxHealth;
        originPos = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(CheckPlayerPos());
        NoticePlayerInRange();
    }

    IEnumerator CheckPlayerPos()
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

    void NoticePlayerInRange()
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
        }
    }
}
