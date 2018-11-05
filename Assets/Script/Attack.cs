using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour {
    public int damage;


    public void InitAttack(int power)
    {
        // receive data from player script
        damage = power;
        this.gameObject.SetActive(true);
    }

}
