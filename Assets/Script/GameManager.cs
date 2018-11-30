using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    private static GameManager instance;
    public static GameManager Instance
    {
        get { return instance; }
    }

    GameObject[] winBreads;
    public GameObject breadSetOne;
    public GameObject breadSetTwo;
    public GameObject breadSetThree;
    
    public bool recIsFound;
    bool firstSetFound;
    bool secondSetFound;


    private void Awake()
    {
        if (instance == null) instance = this;
        else if (instance != this) Destroy(this.gameObject);
    }
    
    void Start () {
        DontDestroyOnLoad(this.gameObject);
        winBreads = GameObject.FindGameObjectsWithTag("Breads");
        breadSetOne = winBreads[2];
        breadSetTwo = winBreads[1];
        breadSetThree = winBreads[0];
        breadSetOne.SetActive(false);
        breadSetTwo.SetActive(false);
        breadSetThree.SetActive(false);
    }
	
	void Update () {
        DisplayWinBread();
	}

    void DisplayWinBread()
    {
        if (recIsFound == true && firstSetFound == false) 
        {
                breadSetOne.SetActive(true);
                recIsFound = false;
                firstSetFound = true;
        }

        if (recIsFound == true && secondSetFound == true)
        {

            breadSetThree.SetActive(true);
            recIsFound = false;
        }

        if (recIsFound == true && firstSetFound == true)
        {
            breadSetTwo.SetActive(true);
            recIsFound = false;
            secondSetFound = true;
        }
    }
}
