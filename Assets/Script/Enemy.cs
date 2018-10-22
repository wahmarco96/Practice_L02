using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour {
    NavMeshAgent agent;
    public Transform player;
    float damage = 1f;
    float maxHealth = 7f;
    float currentHealth;

	// Use this for initialization
	void Start () {
        agent = GetComponent<NavMeshAgent>();
        currentHealth = maxHealth;
	}
	
	// Update is called once per frame
	void Update () {
        StartCoroutine(CheckPlayerPos());
        IsDead();
	}

    IEnumerator CheckPlayerPos()
    {
        agent.SetDestination(player.position);
        yield return new WaitForSeconds(1);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            currentHealth -= damage;
        }
    }

    void IsDead()
    {
        if (currentHealth < 1f)
        {
            Destroy(this.gameObject);
        }
    }

}
