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
    public int heavyDamage = 3;
    public Image damageFlash;
    Color tempDamageFlash;
    float timeToHeal = 10f;
    public float healTimer = 0f;
    public Attack playerAttack;
    public Animator anim;

    public AttackController attaCon;
    // public delegate void Recipe();
    // public static event Recipe RecipeFound;
    public bool recipeFound = false;
    public GameObject recipe;
    public GameManager gm;

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

    public void UseHeavyAttack()
    {
        anim.Play("Heavy");
        playerAttack.InitAttack(heavyDamage);
    }

    public void MiyabiOffering(int skillsDamage)
    {
        damage = skillsDamage;
        //anim.Play("Skill01");
    }
    /*
    public void JamSlam(int slamDamage)
    {
        damage = slamDamage;
        anim.Play("Skill02");
    }

    public void UltimateBro(int UltiDamage)
    {
        damage = UltiDamage;
        anim.Play("Ultimate");
    }
    */
    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            currentHealth -= 1f;
            print("hp");
        }

        if(collision.gameObject.tag == "Recipe")
        {
            recipeFound = true;
            gm.recIsFound = recipeFound;
            recipeFound = false;
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
