using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
[CreateAssetMenu(fileName = "CutsceneLoaderData", menuName = "ScriptableObject/CutsceneLoaderDataObject")]
public class CutsceneLoaderContainer : ScriptableObject
{
    [SerializeField]
    string title, sceneToLoad;
    [SerializeField]
    AudioClip music;
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

    public void SetSceneName(string value)
    {
        sceneToLoad = value;
    }

    public string GetTitle()
    {
       
        return title;
    }

    public string GetSceneToLoad()
    {
        return sceneToLoad;
    }

    public AudioClip GetClip()
    {
        return music;
    }

    public void SetMusic(AudioClip c)
    {
        music = c;
    }
}
