using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class UIManager : MonoBehaviour {
    
    [Header("In Game Setting")]
    public GameObject winLosePanel;
    public Text winLoseText;
    public GameObject settingPanel;
    
    int index;
    public Image black;
    public Animator anim;
    
    public GameObject menuSettingPanel;

    private void OnEnable()
    {
       Player.OnDeath += LosePanel;
    }

    private void OnDisable()
    {
        Player.OnDeath -= LosePanel;
    }

    void LosePanel()
    {
        winLosePanel.SetActive(true);
        winLoseText.text = "Lose";
    }
    
    public void OpenSetting()
    {
        settingPanel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void CloseSettingPanel()
    {
        settingPanel.SetActive(false);
        Time.timeScale = 1f;
    }
    
    public void QuitGame()
    {
        Application.Quit();
    }

    public void Restart()
    {
        Time.timeScale = 1f;
        index = 2;
        StartCoroutine(FadingScene());
    }

    public void MainMenu()
    {
        Time.timeScale = 1f; //timescale will affect the fading animation
        index = 0;
        StartCoroutine(FadingScene());
    }

    public void NewGame()
    {
        index = 1;
       StartCoroutine(FadingScene());
    }

    IEnumerator FadingScene()
    {
        anim.SetBool("Fade", true);
        yield return new WaitUntil(() => black.color.a == 1);
        SceneManager.LoadScene(index);
    }    
}
