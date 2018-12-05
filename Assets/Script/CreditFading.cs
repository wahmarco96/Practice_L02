using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CreditFading : MonoBehaviour {
    public Animator anim;
    public Image black;
    public Image credit;
    Color creditAlpha;
    public Text greeting;
    Color greetingAlpha;
    public Text special;
    Color specialAlpha;
    public Image fadingIn;
    Color fadingAlpha;
    public GameObject quitButton;
	
	// Update is called once per frame
	void Update () {
        Invoke("CongratulationBG", 2f);
        Invoke("SpecialThanks", 2f);
        Invoke("ShowCredit", 6f);
        Invoke("FadeIn", 10f);
        Invoke("Button", 15f);
	}

    public void FadingScene()
    {
        anim.SetBool("Fade", true);
    }

    void ShowCredit()
    {
        creditAlpha = credit.color;
        creditAlpha.a += 1f*Time.deltaTime;
        credit.color = creditAlpha;
    }

    void CongratulationBG()
    {

        greetingAlpha = greeting.color;
        greetingAlpha.a -= 2f * Time.deltaTime;
        greeting.color = greetingAlpha;
    }

    void SpecialThanks()
    {
        specialAlpha = special.color;
        specialAlpha.a += 1f * Time.deltaTime;
        special.color = specialAlpha;
    }

    void FadeIn()
    {
        fadingAlpha = fadingIn.color;
        fadingAlpha.a += 0.5f * Time.deltaTime;
        fadingIn.color = fadingAlpha;
    }

    public void Button()
    {
        quitButton.SetActive(true);
    }

    public void Bye()
    {
        Application.Quit();
    }
}
