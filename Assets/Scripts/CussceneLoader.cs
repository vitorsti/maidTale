using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CussceneLoader : MonoBehaviour
{
    [SerializeField]
    string titleName, cutsceneToLoadName, afinityToloadName;
    [SerializeField]
    CutsceneLoaderContainer data;

    private void Awake()
    {
        data = Resources.Load<CutsceneLoaderContainer>("CutsceneLoaderData");

        GetComponent<Button>().onClick.AddListener(SetCutsceneData);
    }
    public void SetCutsceneData()
    {
        data.SetTitle(titleName);
        data.SetCutsceneToLoadName(cutsceneToLoadName);
        data.SetAfinityToLoadName(afinityToloadName);

        SceneManager.LoadScene("CutsceneLoader");
    }
}
