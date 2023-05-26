using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    [SerializeField]
    GameObject levelSelectionScreen, creditScreen;
   
    int index;
    private void Awake()
    {
        index = PlayerPrefs.GetInt("LevelSelectionScreen", 0);

        if (levelSelectionScreen.activeInHierarchy&&levelSelectionScreen!=null)
            levelSelectionScreen.SetActive(false);
        if (creditScreen.activeInHierarchy && creditScreen != null)
            creditScreen.SetActive(false);
    }
    // Start is called before the first frame update
    void Start()
    {
        if(index == 1)
            levelSelectionScreen.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("MENU"))
        {
            if(levelSelectionScreen.activeInHierarchy)
            {
                LevelSelectionScreen(false);
            }

            if (creditScreen.activeInHierarchy)
            {
                CreditScreen(false);
            }

        }

        if (Input.GetButtonDown("VERDE0"))
        {
            if (!creditScreen.activeInHierarchy)
                LevelSelectionScreen(true);
        }

        if (Input.GetButtonDown("AZUL0"))
        {
            if(!levelSelectionScreen.activeInHierarchy)
            CreditScreen(true);
        }

        if (Input.GetButtonDown("VERMELHO0"))
        {
            //QuitGame();
        }
    }
    public void LevelSelectionScreen(bool value)
    {
        levelSelectionScreen.SetActive(value);
    }

    public void CreditScreen(bool value)
    {
        creditScreen.SetActive(value);
    }
    public void QuitGame()
    {
#if UNITY_EDITOR
        Debug.Log("Quit");
#endif
        Application.Quit();
    }
}
