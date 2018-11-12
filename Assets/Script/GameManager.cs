using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    private static GameManager instance;
    public static GameManager Instance
    {
        get { return instance; }
    }

    public GameObject breadSetOne;
    public GameObject breadSetTwo;
    public GameObject breadSetThree;
    
    public bool recIsFound;
    public bool firstSetFound;
    public bool secondSetFound;

    private void Awake()
    {
        if (instance == null) instance = this;
        else if (instance != this) Destroy(this.gameObject);
    }

    // Use this for initialization
    void Start () {
        DontDestroyOnLoad(this.gameObject);
        breadSetOne.SetActive(false);
        breadSetTwo.SetActive(false);
        breadSetThree.SetActive(false);
        
    }
	
	// Update is called once per frame
	void Update () {
        ShowWinBreadOne();
	}

    

  /*void ShowWinBreadOne()
    {
        if (recIsFound == true)
        { 
            if(firstSetFound == false)
            {
                breadSetOne.SetActive(true);
                recIsFound = false;
                firstSetFound = true;
            }
       
            if(firstSetFound == true)
            {
                breadSetTwo.SetActive(true);
                recIsFound = false;
                secondSetFound = true;
            }

            if (secondSetFound == true) 
            {
             breadSetThree.SetActive(true);
            }
        }
    }*/


    void ShowWinBreadOne()
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
            secondSetFound = true;
        }

        if (recIsFound == true && firstSetFound == true)
        {
            breadSetTwo.SetActive(true);
            recIsFound = false;
            secondSetFound = true;
        }
        
    }


    /* private void OnEnable()
       {
           if()
           Player.RecipeFound += ShowWinBreadOne;
       }

       private void OnDisable()
       {
           Player.RecipeFound -= ShowWinBreadOne;
       }*/
}
