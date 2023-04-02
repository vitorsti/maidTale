using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

[CreateAssetMenu(fileName = "Conversation Container", menuName = "ScriptableObject/ConversationContainerObject")]
public class DialogueContainer : ScriptableObject
{
    [SerializeField]
    private string characterDialogue;
    [SerializeField]
    private Sprite ch1, ch2;
    [SerializeField]
    private bool dialogueEnded;
    [Serializable]
    private struct dialogueData { public int id; [TextArea] public string text; public bool hasChoice; [TextArea] public string goodChoice, badChoice; public Color c1, c2; public Sprite e1, e2; public bool choiced; public float afinityToAdd; public float afinityToRemove; }
    [SerializeField]
    private dialogueData[] data;

    private void OnValidate()
    {
        for (int i = 0; i < data.Length; i++)
        {
            data[i].id = i;
            data[i].c1.a = 1;
            data[i].c2.a = 1;
        }
    }

    public string GetText(int id)
    {
        return data.FirstOrDefault(x => x.id == id).text;
    }
    public Color GetColor(int id, int colorIndex)
    {
        if (colorIndex == 0)
            return data.FirstOrDefault(x => x.id == id).c1;
        else
            return data.FirstOrDefault(x => x.id == id).c2;
    }

    public Sprite GetExpression(int id, int expressionIndex)
    {
        if (expressionIndex == 0)
            return data.FirstOrDefault(x => x.id == id).e1;
        else
            return data.FirstOrDefault(x => x.id == id).e2;
    }

    public Sprite GetCharacterSprite1()
    {
        return ch1;
    }

    public Sprite GetCharacterSprite2()
    {
        return ch2;
    }
    public bool GetHasChoice(int id)
    {
        return data.FirstOrDefault(x => x.id == id).hasChoice;
    }

    public string GetGoodChoice(int id)
    {
        return data.FirstOrDefault(x => x.id == id).goodChoice;
    }

    public string GetBadChoice(int id)
    {
        return data.FirstOrDefault(x => x.id == id).badChoice;
    }
    public int GetLength()
    {
        return data.Length;
    }

    public bool GetChoiced(int id)
    {
        return data.FirstOrDefault(x => x.id == id).choiced;
    }

    public void SetChoiced(int id, bool value)
    {
        int i = Array.FindIndex(data, x => x.id == id);
        data[i].choiced = value;
    }

    public bool GetDialogueEnded()
    {
        return dialogueEnded;
    }

    public void SetDialogueEnd(bool value)
    {
        dialogueEnded = value;
    }
    public float GetAfinityToAdd(int id)
    {
        return data.FirstOrDefault(x => x.id == id).afinityToAdd;
    }
    public float GetAfinityToRemove(int id)
    {
        return data.FirstOrDefault(x => x.id == id).afinityToRemove;
    }
}
