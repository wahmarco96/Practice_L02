using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

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
    bool allRecipeFound;
    public int level;

    Animator anim;
    Image black;
    int index = 2;


    private void Awake()
    {
        if (instance == null) instance = this;
        else if (instance != this) Destroy(this.gameObject);
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        winBreads = GameObject.FindGameObjectsWithTag("Breads");
        anim = GameObject.FindGameObjectWithTag("FadingBlack").GetComponent<Animator>();
        black = GameObject.FindGameObjectWithTag("FadingBlack").GetComponent<Image>();

        breadSetOne = winBreads[2];
        breadSetTwo = winBreads[1];
        breadSetThree = winBreads[0];
        breadSetOne.SetActive(firstSetFound);
        breadSetTwo.SetActive(secondSetFound);
        breadSetThree.SetActive(allRecipeFound);
    }

    void Start () {
        DontDestroyOnLoad(this.gameObject);
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
           StartCoroutine(FadingScene());
           level += 1;
        }

        if (recIsFound == true && secondSetFound == true)
        {
            breadSetThree.SetActive(true);
            recIsFound = false;
            index = 3;
            StartCoroutine(FadingScene());
        }

        if (recIsFound == true && firstSetFound == true)
        {
            breadSetTwo.SetActive(true);
            recIsFound = false;
            secondSetFound = true;
            StartCoroutine(FadingScene());
            level += 2;
        }
    }
    
    public IEnumerator FadingScene()
    {
        anim.SetBool("Fade", true);
        yield return new WaitUntil(() => black.color.a == 1);
        SceneManager.LoadScene(index);
    }
}
