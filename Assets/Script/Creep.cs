using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creep : Enemy {
    

    // Use this for initialization
    protected override void Start () {
        maxHealth = 5f;
        base.Start();
	}
	
	// Update is called once per frame
	public override void Update () {
        base.Update();
	}
}
