using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroSkipScene : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Invoke("NextScene", 10);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void NextScene()
    {
        SceneManager.LoadScene(2);
    }
}
