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

    //bool thisDialogueHasChoice
    bool choiceRootDialogue = false;
    int rootIndex;
    public int rootLength;
    bool _goodOrBadRoot;
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
        //NextText();
        SetText(index, choiceRootDialogue, 0, false);
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

    void SetText(int value, bool choiceRootDialogue, int rootValue, bool goodOrBadChoice)
    {
        if (!choiceRootDialogue)
            dialogueText = dialogueData.GetText(value);
        else
            dialogueText = dialogueData.GetRootText(value, rootValue, goodOrBadChoice);
    }


    public void NextText()
    {

        if (!choiceRootDialogue)
        {
            index++;
            // Debug.Log(index);


            if (index == length)
            {
#if !UNITY_EDITOR
          //  dialogueData.SetDialogueEnd(true);
#else
                Debug.Log("dialogu ended");
#endif
            }
            if (index > length)
            {
                index = length;

            }
            SetText(index, choiceRootDialogue, 0, false);
        }
        else
        {
            Debug.Log(index);
            Debug.Log(rootIndex);
            if (rootIndex == rootLength)
            {
                //rootIndex = rootLength;
                choiceRootDialogue = false;
                Debug.Log(rootLength);
                NextText();
                //index++;
                //return;
            }
            /*if (rootIndex == rootLength)
                choiceRootDialogue = false;*/

            if (choiceRootDialogue)
            {
                SetText(index, choiceRootDialogue, rootIndex, _goodOrBadRoot);
                rootIndex++;
            }

        }

        /*if (!choiceRootDialogue)
            SetText(index, false, 0, false);
        else
        {

            Debug.Log(rootIndex);
            SetText(rootIndex, true, rootIndex, _goodOrBadRoot);
        }*/

    }

    public void PreviousText()
    {
        index--;

        if (index < 0)
            index = 0;

        SetText(index, choiceRootDialogue, 0, false);
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
        Debug.Log("AfinityRemoved");
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

    public void SetChoiceRoot(bool value)
    {
        choiceRootDialogue = true;
        _goodOrBadRoot = value;
        rootIndex = 0;
        rootLength = dialogueData.GetRootlength(index, _goodOrBadRoot);
    }

    public bool IsRootDialogue()
    {
        return choiceRootDialogue;
    }
}
