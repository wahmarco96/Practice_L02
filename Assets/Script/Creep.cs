using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creep : Enemy {
    

    // Use this for initialization
    protected override void Start () {
        base.Start();
        maxHealth = 5f;
        maxHealth += gameLevel;
	}
	
	// Update is called once per frame
	public override void Update () {
        base.Update();
	}
}
