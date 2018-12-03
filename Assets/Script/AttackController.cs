using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AttackController : MonoBehaviour { // this script controll the player script (then use player script to control others)
    
    public Image cdMask1;
    public Image cdMask2;
    public Image cdMask3;
    float skillCD = 8f;
    float skillCDLeft;
    public bool skillIsReady;
    float skillCD2 = 10f;
    float skillCD2Left;
    bool skill2IsReady;
    float skillCD3 = 15f;
    float skillCD3Left;
    bool skill3IsReady;

    public Animator anim;

    public Player playerData;


     /*bool skill1IsActivated  for player script (needed to manipulate player hp)(and enemy hp)
       void skillOneDamage() */

    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
        SkillCoolDown();
    }

    public void NormalAttack()
    {
        // activate 
        playerData.UseAttack();
    }

    public void HeavyAttack()
    {
        playerData.UseHeavyAttack();
    }

    public void SkillOne()
    {
        if (skillIsReady == true)
        {
            AudioManager.Instance.SfxBuff();
            playerData.MiyabiOffering(5);
            Invoke("DeactivatedSkillOne", 4f);
            skillCDLeft = skillCD;
            playerData.anim.Play("Skill01");
        }
    }

    void DeactivatedSkillOne()
    {
        playerData.MiyabiOffering(1);
    }


    public void SkillTwo()
    {
        if(skill2IsReady == true)
        {
            playerData.anim.Play("Skill02");
            AudioManager.Instance.SfxJumpSlash();
            skillCD2Left = skillCD2;
        }
    }

    public void SkillThree()
    {
        if (skill3IsReady == true)
        {
            AudioManager.Instance.SfxUlti();
            playerData.anim.Play("Ultimate");
            skillCD3Left = skillCD3;
        }
    }

    void SkillCoolDown()
    {
        skillCDLeft -= Time.deltaTime;
        cdMask1.fillAmount = skillCDLeft / skillCD;

        skillCD2Left -= Time.deltaTime;
        cdMask2.fillAmount = skillCD2Left / skillCD2;

        skillCD3Left -= Time.deltaTime;
        cdMask3.fillAmount = skillCD3Left / skillCD3;

        if ( cdMask1.fillAmount == 0f)
        {
            skillIsReady = true;
        }

        else skillIsReady = false;

        if (cdMask2.fillAmount == 0f)
        {
            skill2IsReady = true;
        }

        else skill2IsReady = false;

        if (cdMask3.fillAmount == 0f)
        {
            skill3IsReady = true;
        }
        
        else skill3IsReady = false;
    }
}
