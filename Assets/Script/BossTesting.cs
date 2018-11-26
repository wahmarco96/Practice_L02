using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossTesting : EnemyTesting {
    public GameObject rec;
    GameObject recCopies;


	// Use this for initialization
	protected override void Start () {
        maxHealth = 20f;
        base.Start();
	}
	
	// Update is called once per frame
	public virtual void Update () {
        base.Update();
        Drops();
    }
    
    void Drops()
    {
        if (bossIsDead == true)
        {
            Instantiate(rec, this.transform.position, Quaternion.identity);
            bossIsDead = false;
        }
    }
}
