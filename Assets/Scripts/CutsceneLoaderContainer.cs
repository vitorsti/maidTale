using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CutsceneLoaderData", menuName = "ScriptableObject/CutsceneLoaderDataObject")]
public class CutsceneLoaderContainer : ScriptableObject
{
    [SerializeField]
    string title;
    public void SetCutsceneToLoadName(string value)
    {
        PlayerPrefs.SetString("CutsceneToLoad", value);
    }

    public void SetAfinityToLoadName(string value)
    {
        PlayerPrefs.SetString("AfinityToLoad", value);
    }

    public string GetCutsceneToLoadName()
    {
        return PlayerPrefs.GetString("CutsceneToLoad");
    }

    public string GetAfinityToLoadName()
    {
        return PlayerPrefs.GetString("AfinityToLoad");
    }

    public void SetTitle(string value)
    {
        title = value;
    }

    public string GetTitle()
    {
        return title;
    }
}
