using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    public string DialogueName;
    [SerializeField]
    private DialogueContainer dialogueData;
    [SerializeField]
    [TextArea]
    private string dialogueText;
    [SerializeField]
    private int index;
    [SerializeField]
    private int length;

    public DialogueUiDisplay display;

    // Start is called before the first frame update
    void Awake()
    {
        var data = Resources.Load<DialogueContainer>("Dialogues/" + DialogueName);

        if (data != null)
        {
            dialogueData = data;
            length = dialogueData.GetLength() - 1;
        }

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

        if (Input.GetKeyDown(KeyCode.RightArrow))
            NextText();

        if (Input.GetKeyDown(KeyCode.LeftArrow))
            PreviousText();
#endif
    }

    void SetText(int value)
    {
        dialogueText = dialogueData.GetText(value);
    }

    public void NextText()
    {
        index++;

        if (index > length)
            index = length;

        SetText(index);
    }

    public void PreviousText()
    {
        index--;

        if (index < 0)
            index = 0;

        SetText(index);
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
}
