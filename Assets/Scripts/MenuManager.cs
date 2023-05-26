using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    [SerializeField]
    GameObject levelSelectionScreen, creditScreen;
    private void Awake()
    {
        if (levelSelectionScreen.activeInHierarchy&&levelSelectionScreen!=null)
            levelSelectionScreen.SetActive(false);
        if (creditScreen.activeInHierarchy && creditScreen != null)
            creditScreen.SetActive(false);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
