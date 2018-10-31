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

    [Header("Menu Setting")]
    public GameObject menuSettingPanel;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}

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

    public void OpenMenuSetting()
    {
        menuSettingPanel.SetActive(true);
    }

    public void CloseMenuSettingPanel()
    {
        menuSettingPanel.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void Restart()
    {

    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void NewGame()
    {
        SceneManager.LoadScene(1);
    }
}
