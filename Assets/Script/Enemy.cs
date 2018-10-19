using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour {
    NavMeshAgent agent;
    public Transform player;


	// Use this for initialization
	void Start () {
        agent = GetComponent<NavMeshAgent>();
	}
	
	// Update is called once per frame
	void Update () {
        StartCoroutine(CheckPlayerPos());
	}

    IEnumerator CheckPlayerPos()
    {
        agent.SetDestination(player.position);
        yield return new WaitForSeconds(1);
    }
}
