using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    [SerializeField]
    private string dialogueToLoad;
    [SerializeField]
    private string afinityToLoad;
    [SerializeField]
    private DialogueContainer dialogueData;
    [SerializeField]
    private AfinityContainer afinityData;
    [SerializeField]
    [TextArea]
    private string dialogueText;
    private string dialogueEndedText;
    [SerializeField]
    private int index;
    [SerializeField]
    private int length;

    [SerializeField]
    private DialogueUiDisplay display;

    // Start is called before the first frame update
    void Awake()
    {
        var data = Resources.Load<DialogueContainer>("Dialogues/" + dialogueToLoad);

        if (data != null)
        {
            dialogueData = data;
            length = dialogueData.GetLength() - 1;
        }

        var afinity = Resources.Load<AfinityContainer>("Afinities/" + afinityToLoad);

        if (afinity != null)
        {
            afinityData = afinity;
        }

        display = FindObjectOfType<DialogueUiDisplay>();
    }

    private void Start()
    {
        index = 0;
        SetText(index);
    }

    // Update is called once per frame
    void Update()
    {
#if UNITY_EDITOR

        /*if (Input.GetKeyDown(KeyCode.Space))
            StartDialogue();*/

        /*if (Input.GetKeyDown(KeyCode.RightArrow))
            NextText();

        if (Input.GetKeyDown(KeyCode.LeftArrow))
            PreviousText();*/
#endif
    }

    void SetText(int value)
    {
        dialogueText = dialogueData.GetText(value);
    }

    public void NextText()
    {
        index++;
        if(index == length)
        {
            dialogueData.SetDialogueEnd(true);
        }
        if (index > length)
        {
            index = length;
            
        }

        SetText(index);
    }

    public void PreviousText()
    {
        index--;

        if (index < 0)
            index = 0;

        SetText(index);
    }
    public Color GetColor(int colorIndex)
    {
        return dialogueData.GetColor(index, colorIndex);
    }

    public Sprite GetExpression(int expressionIndex)
    {
        return dialogueData.GetExpression(index, expressionIndex);
    }

    public Sprite GetCharacterSprite1()
    {
        return dialogueData.GetCharacterSprite1();
    }

    public Sprite GetCharacterSprite2()
    {
        return dialogueData.GetCharacterSprite2();
    }
    public bool GetHasChoice()
    {
        return dialogueData.GetHasChoice(index);
    }

    public string GetGoodChoice()
    {
        return dialogueData.GetGoodChoice(index);
    }
    public string GetBadChoice()
    {
        return dialogueData.GetBadChoice(index);
    }
    public string GetText()
    {
        return dialogueText;
    }

    public void StartDialogue()
    {
        display.dialogueManager = this;
        display.SetThings();
    }
    public bool GetDialogueEnded()
    {
        return dialogueData.GetDialogueEnded();
    }
    public string GetTextEnded()
    {
        return dialogueData.GetTextEnded();
    }
    public void AddAfinity()
    {
#if UNITY_EDITOR
        Debug.Log("AfinityAdded");
        afinityData.IncreaseAfinity(dialogueData.GetAfinityToAdd(index));
        return;
#endif
        if (!dialogueData.GetChoiced(index))
        {
            dialogueData.SetChoiced(index, true);
            afinityData.IncreaseAfinity(dialogueData.GetAfinityToAdd(index));
            Debug.Log("AfinityIncreased");
        }
        
    }
    public void RemoveAfinity()
    {
#if UNITY_EDITOR
        Debug.Log("AfinityAdded");
        afinityData.DecreaseAfinity(dialogueData.GetAfinityToRemove(index));
        return;
#endif
        if (!dialogueData.GetChoiced(index))
        {
            dialogueData.SetChoiced(index, true);
            afinityData.DecreaseAfinity(dialogueData.GetAfinityToRemove(index));
            Debug.Log("AfinityDecreased");
        }
    }

}
