using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    public string dialogueToLoad;
    [SerializeField]
    private DialogueContainer dialogueData;
    [SerializeField]
    [TextArea]
    private string dialogueText;
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
    public Color GetColor(int colorIndex)
    {
        return dialogueData.GetColor(index, colorIndex);
    }

    public Sprite GetExpression(int colorIndex)
    {
        return dialogueData.GetExpression(index, colorIndex);
    }

    public Sprite GetCharacterSprite1()
    {
        return dialogueData.GetCharacterSprite1();
    }

    public Sprite GetCharacterSprite2()
    {
        return dialogueData.GetCharacterSprite2();
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
