using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour {
    public GameObject rec;
    GameObject recCopies;
    bool bossDeath = false;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        Drops();
	}

    void Death()
    {
        Destroy(this.gameObject);
        bossDeath = true;
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
