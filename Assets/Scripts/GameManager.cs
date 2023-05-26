using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instace;
    public GameObject buttonMenu;
    public GameObject buttonMenu2;
    public GameObject buttonDayEnd;
    public GameObject[] levels;
    public enum GameState { none,pause, play, interaction, cutscene}
    public GameState _state;
    [SerializeField]
    string sceneToLoad;
    /*public GameManager(GameState nState)
    {
        instace = this;
        _state = nState;
    }

    GameManager gm = new GameManager(GameState.play);*/
   
    // Start is called before the first frame update
    void Awake()
    {

        instace = this;
       
        _state = GameState.play;

        //PlayerPrefs.SetInt("LevelSelected", 1);
        
    }

    private void Start()
    {
        if(SceneManager.GetActiveScene().name == "Game")
        {

            BeginLevel();

        }
    }
    // Update is called once per frame
    /*void Update()
    {

        if (Input.GetButtonDown("VERDE0") && SceneManager.GetActiveScene().name == "intro")
        {
            if(buttonMenu.activeInHierarchy)
            buttonMenu.GetComponent<Button>().onClick.Invoke();
        }

        if (Input.GetButtonDown("VERDE0") && SceneManager.GetActiveScene().name == "intro")
        {
            if(buttonMenu2.activeInHierarchy)
                buttonMenu2.GetComponent<Button>().onClick.Invoke();
        }
        if (Input.GetButtonDown("VERDE0") && SceneManager.GetActiveScene().name == "Day1Scene")
        {
            buttonMenu.GetComponent<Button>().onClick.Invoke();
        }

        if (Input.GetButtonDown("VERDE0") && SceneManager.GetActiveScene().name == "Game")
        {
            if (buttonDayEnd.activeInHierarchy)
            {
                buttonDayEnd.GetComponent<Button>().onClick.Invoke();
            }
        }

        if (Input.GetButtonDown("VERDE0") && SceneManager.GetActiveScene().name == "CutsceneLoader")
        {
            buttonMenu.GetComponent<Button>().onClick.Invoke();
        }
    }*/
    public void BeginLevel()
    {
     
        int index = PlayerPrefs.GetInt("LevelSelected", 0);

        foreach(GameObject i in levels)
        {
            i.SetActive(false);
        }

        levels[index].SetActive(true);

        TaskManager.instance.SetThings();

        TimerManager.instance.StartTimer();

        
    }
    public void SetState(GameState state)
    {
        _state = state;
    }

    public GameState GetState()
    {
        return _state;
    }

    public void OnEndCutScene()
    {
        SceneManager.LoadScene(sceneToLoad);
      
    }

    //public void BackToMenu()
}
