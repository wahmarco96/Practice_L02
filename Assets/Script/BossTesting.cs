using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossTesting : EnemyTesting {
    public GameObject rec;
    GameObject recCopies;
    bool bossDeath = false;


	// Use this for initialization
	void Start () {
        maxHealth = 10f;
	}
	
	// Update is called once per frame
	public virtual void Update () {
        base.Update();
	}

    void Death()
    {
        Destroy(this.gameObject);
        bossDeath = true;
        Drops();
    }

    void Drops()
    {
        if (bossDeath == true)
        {
           recCopies = Instantiate(rec, this.transform.position, Quaternion.identity);
           bossDeath = false;
        }
    }
}
