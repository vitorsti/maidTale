using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

[CreateAssetMenu(fileName = "Conversation Container", menuName = "ScriptableObject/ConversationContainerObject")]
public class DialogueContainer : ScriptableObject
{
    [Serializable]
    private struct dialogueData { public int id; [TextArea] public string text; }
    [SerializeField]
    private dialogueData[] data;

    private void OnValidate()
    {
        for(int i = 0; i < data.Length; i++)
        {
            data[i].id = i;
        }
    }

    public string GetText(int id)
    {
        return data.FirstOrDefault(x => x.id == id).text;
    }

    public int GetLength()
    {
        return data.Length;
    }
}
