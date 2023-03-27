using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

[CreateAssetMenu(fileName = "Conversation Container", menuName = "ScriptableObject/ConversationContainerObject")]
public class DialogueContainer : ScriptableObject
{
    [Serializable]
    private struct dialogueData { public int id; [TextArea] public string text; public Color c1,c2;public Sprite e1,e2;}
    [SerializeField]
    private dialogueData[] data;

    private void OnValidate()
    {
        for(int i = 0; i < data.Length; i++)
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
        if(colorIndex == 0)
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
    public int GetLength()
    {
        return data.Length;
    }
}
