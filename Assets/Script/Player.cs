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
    //float timeToHeal = 10f;
    public float healTimer = 0f;
    public Attack playerAttack;

    public ControllerManager coMa;
    public bool isAttacking;
    
   public Animator anim;

    AttackController attacCon;
    // public delegate void Recipe();
    // public static event Recipe RecipeFound;
    public bool recipeFound = false;
    public GameObject recipe;
    public GameManager gm;

    // Use this for initialization
    void Start () {
        gm = GameObject.FindGameObjectWithTag("Game Manager").GetComponent<GameManager>();
        //anim = GetComponent<Animator>();
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
        //attacCon.anim.Play("ComboA");

   
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("Walking_Front") || anim.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
        {
            anim.Play("ComboA");
        }
        else
        {
            anim.SetTrigger("ContinueCombo");
        }

        playerAttack.InitAttack(damage);
        isAttacking = true;
    }

    public void UseHeavyAttack()
    {
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("ComboC") == false && anim.GetCurrentAnimatorStateInfo(0).IsName("Heavy") == false) 
        {

            if(anim.GetCurrentAnimatorStateInfo(0).IsName("ComboA") || anim.GetCurrentAnimatorStateInfo(0).IsName("ComboB"))
            {
             anim.SetTrigger("ContinueToHeavy");
            }
            else
            {
                 anim.Play("Heavy");
            }
        
            playerAttack.InitAttack(heavyDamage);
            isAttacking = true;
        }
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
            anim.Play("Hurt");
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
            anim.Play("Dead");
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
        if (currentHealth < 10f)
        {
            healTimer += 1f;
        }
        if (healTimer >= 300f)
        {
            currentHealth += 1f;
            healTimer = 0f;
        }
    }

    void DoYouKnowDaWey()
    {
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("ComboA") && (anim.GetCurrentAnimatorStateInfo(1).IsName("Heavy")))
        {
            anim.SetTrigger("ContinueHeavyCombo");
        }
        else
        {
            anim.Play("Heavy");
        }
    }

   
}
