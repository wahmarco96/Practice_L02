using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class IntroSkipScene : MonoBehaviour {
    public int index;
    public Image black;
    public Animator anim;

    // Use this for initialization
    void Start () {
        Invoke("NextScene", 8);
	}

    void NextScene()
    {
        StartCoroutine(FadingScene());
    }

    public IEnumerator FadingScene()
    {
        anim.SetBool("Fade", true);
        yield return new WaitUntil(() => black.color.a == 1);
        SceneManager.LoadScene(2);
    }
}
