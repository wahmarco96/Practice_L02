using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {

    public delegate void DelDeath();
    public static event DelDeath OnDeath;
    float maxHealth = 10;
    public float currentHealth;
    public int damage = 1;
    public Image damageFlash;
    Color tempDamageFlash;
    float timeToHeal = 10f;
    public float healTimer = 0f;
    public Attack playerAttack;
    Animator anim;

    

    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();
        currentHealth = maxHealth;
        damageFlash = damageFlash.GetComponent<Image>();
        tempDamageFlash = damageFlash.color;
        tempDamageFlash.a = 0f;
        damageFlash.color = tempDamageFlash;
    }
	
	// Update is called once per frame
	void Update () {
        LowHealth();
        TimeToHeal();
    }

   public void UseAttack()
    {
        // transfering my player data to others script
        // play animation as well
        anim.Play("ComboA");
        playerAttack.InitAttack(damage);
    }

    public void MiyabiOffering(int skillsDamage)
    {
        damage = skillsDamage;
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            currentHealth -= 1f;
            print("hp");
        }
    }

    public void IsDeath()
    {
        if (currentHealth < 1f)
        {
            if (OnDeath != null) OnDeath();
            Destroy(this.gameObject);
        
        }
    }

    void LowHealth()
    {
        IsDeath();
        if (currentHealth <5f)
        {
            tempDamageFlash.a = 1f;
            damageFlash.color = tempDamageFlash;
        }
        else
        {
            damageFlash.color = Color.clear;
        }
    }

    void TimeToHeal()
    {
        if (currentHealth < 5f)
        {
            healTimer += 1f;
        }
        if (healTimer >= 300f)
        {
            currentHealth += 1f;
            healTimer = 0f;
        }
    }
}
