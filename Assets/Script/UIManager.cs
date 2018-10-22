using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {
    public GameObject winLosePanel;
    public Text winLoseText;


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
}
