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
    string levelAfinity;
    [SerializeField]
    int levelToEnable;
    [SerializeField]
    CutsceneLoaderContainer data;
    public enum SceneType { BeginLevel, EndLevel }
    public SceneType type;

    private void Awake()
    {
        //if(type == SceneType.BeginLevel)
        data = Resources.Load<CutsceneLoaderContainer>("CutsceneLoaderData");
        //else
        //data = Resources.Load<CutsceneLoaderContainer>("EndData");


        GetComponent<Button>().onClick.AddListener(SetCutsceneData);
    }
    private void Update()
    {
        if (Input.GetButtonDown("PRETO0"))
        {
            GetComponent<Button>().onClick.Invoke();
        }
    }
    public void SetCutsceneData() { 
    
        if(type == SceneType.BeginLevel){
        PlayerPrefs.SetInt("LevelSelected", levelToEnable);
        PlayerPrefs.SetString("LevelAfinity", levelAfinity);
        }
        data.SetTitle(titleName);
        data.SetSceneName(sceneToload);
        data.SetCutsceneToLoadName(cutsceneToLoadName);
        data.SetAfinityToLoadName(afinityToloadName);

        SceneManager.LoadScene("CutsceneLoader");

        
    }

    public void SetInt() { PlayerPrefs.SetInt("LevelSelectionScreen", 1); }
}
