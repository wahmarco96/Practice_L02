using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AttackController : MonoBehaviour { // this script controll the player script (then use player script to control others)
    
    public Image cdMask1;
    public Image cdMask2;
    public Image cdMask3;
    float skillCD = 5f;
    float skillCDLeft;
    public bool skillIsReady;
    float skillCD2 = 10f;
    float skillCD2Left;
    bool skill2IsReady;
    float skillCD3 = 15f;
    float skillCD3Left;
    bool skill3IsReady;
    
    public Player playerData;


     /*bool skill1IsActivated  for player script (needed to manipulate player hp)(and enemy hp)
       void skillOneDamage() */

    // Use this for initialization
    void Start () {

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
            playerData.MiyabiOffering(5);
            Debug.Log("Skill1Activated");
            Invoke("DeactivatedSkillOne", 4f);
            skillCDLeft = skillCD;
            playerData.anim.Play("Skill01");
        }

        else Debug.Log("Skill is not available yet");
    }

    void DeactivatedSkillOne()
    {
        playerData.MiyabiOffering(1);
        Debug.Log("skill is finished");
    }


    public void SkillTwo()
    {
        if(skill2IsReady == true)
        {
            playerData.anim.Play("Skill02");
            Debug.Log("skill2");
            skillCD2Left = skillCD2;
        }

        else Debug.Log("Skill 2 is not available yet");
    }

    public void SkillThree()
    {
        if (skill3IsReady == true)
        {
            playerData.anim.Play("Ultimate");
            Debug.Log("skill3");
            skillCD3Left = skillCD3;
        }

        else Debug.Log("Skill 3 is not available yet");
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

    
    void DeactivatedSkillTwo()
    {

    }

    void DeactivatedSkillThree()
    {

    }
}
