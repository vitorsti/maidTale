using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CussceneLoader : MonoBehaviour
{
    [SerializeField]
    string titleName, cutsceneToLoadName, afinityToloadName, sceneToload;
    [SerializeField]
    CutsceneLoaderContainer data;

    private void Awake()
    {
        data = Resources.Load<CutsceneLoaderContainer>("CutsceneLoaderData");

        GetComponent<Button>().onClick.AddListener(SetCutsceneData);
    }
    private void Update()
    {
        
    }
    public void SetCutsceneData()
    {
        data.SetTitle(titleName);
        data.SetSceneName(sceneToload);
        data.SetCutsceneToLoadName(cutsceneToLoadName);
        data.SetAfinityToLoadName(afinityToloadName);

        SceneManager.LoadScene("CutsceneLoader");

        if(titleName == "Intro")
        {
            PlayerPrefs.SetInt("levels", 1);
        }
    }
}
