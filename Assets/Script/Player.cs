﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {
    float maxHealth = 5;
    public float currentHealth;
    float damage = 1f;
    public Image damageFlash;
    Color tempDamageFlash;
    float timeToHeal = 5f;
   public float healTimer = 0f;

    // Use this for initialization
    void Start () {
        currentHealth = maxHealth;
        damageFlash = damageFlash.GetComponent<Image>();
        tempDamageFlash = damageFlash.color;
        tempDamageFlash.a = 0f;
        damageFlash.color = tempDamageFlash;
    }
	
	// Update is called once per frame
	void Update () {
        LowHealth();
        IsDeath();
        TimeToHeal();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            currentHealth -= 1f;
            print("hp");
        }
    }

    void IsDeath()
    {
        if (currentHealth == 0f)
        {
            Destroy(this.gameObject);
        }
    }

    void LowHealth()
    {
        if(currentHealth <5f)
        {
            tempDamageFlash.a = 1f;
            damageFlash.color = tempDamageFlash;
        }
    }

    void TimeToHeal()
    {
        if (currentHealth < 5f)
        {
            healTimer += 1f;
        }
        if (healTimer == 300f)
        {
            currentHealth += 1f;
            healTimer = 0f;
        }
    }
}
