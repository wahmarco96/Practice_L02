using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : Enemy
{
    public GameObject rec;
    
    // Use this for initialization
    protected override void Start()
    {
        base.Start();
        maxHealth = 20f;
        maxHealth += gameLevel;
    }

    // Update is called once per frame
    public override void Update()
    {
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
