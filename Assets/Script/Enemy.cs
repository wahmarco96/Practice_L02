using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Enemy : MonoBehaviour {

    NavMeshAgent agent;
    public Transform player;
    float maxHealth = 5f;
    public float currentHealth;
    public bool playerAlive =true;
    public Image currentHealthBar;
    public bool playerInRange;
    public float takeDamage;
    public AttackController attackDamage;

    Vector3 originPos;

    // Use this for initialization
    void Start () {
        agent = GetComponent<NavMeshAgent>();
        currentHealth = maxHealth;
        originPos = this.transform.position;
    }
	
	// Update is called once per frame
	void Update () {
        StartCoroutine(CheckPlayerPos());
        IsDead();
        TakeDamage();
        CheckCurrentHealth();
        NoticePlayerInRange();
    }

    IEnumerator CheckPlayerPos()
    {
        if (playerInRange == true)
        {
            agent.SetDestination(player.position);
            yield return new WaitForSeconds(1);
        }
        
       else
        {
            agent.SetDestination(originPos);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            currentHealth -= takeDamage;
        }
    }

    void IsDead()
    {
        if (currentHealth < 1f)
        {
            Destroy(this.gameObject);
        }
    }

    void TakeDamage()
    {
        takeDamage = attackDamage.playerAttackDamage;
    }

    void CheckCurrentHealth()
    {
        currentHealthBar.fillAmount = currentHealth / maxHealth;
    }

    void NoticePlayerInRange()
    {
        if (Vector3.Distance(player.position, this.transform.position) < 60f)
        {
            playerInRange = true;
        }
        else
        {
            playerInRange = false;
        }
    }
}
