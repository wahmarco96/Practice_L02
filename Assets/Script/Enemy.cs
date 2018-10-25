using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour {
    NavMeshAgent agent;
    public Transform player;
    float maxHealth = 7f;
    public float currentHealth;
    public bool playerAlive =true;

    public float takeDamage;
    public AttackController attackDamage;

    // Use this for initialization
    void Start () {
        agent = GetComponent<NavMeshAgent>();
        currentHealth = maxHealth;
    }
	
	// Update is called once per frame
	void Update () {
        StartCoroutine(CheckPlayerPos());
        IsDead();
        TakeDamage();
    }

    IEnumerator CheckPlayerPos()
    {
            agent.SetDestination(player.position);
            yield return new WaitForSeconds(1);
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
}
