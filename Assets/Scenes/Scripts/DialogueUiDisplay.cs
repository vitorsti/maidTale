using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueUiDisplay : MonoBehaviour
{
    public DialogueManager dialogueManager;
    [SerializeField]
    private float displayTextDelay;
    [SerializeField]
    private char[] splited;
    [SerializeField]
    private GameObject UiObject;
    [SerializeField]
    private TextMeshProUGUI displayText;
    [SerializeField]
    private Button nextButton, previousButton, endDialogueButton;

    private void Awake()
    {
        UiObject.SetActive(false);
        endDialogueButton.onClick.AddListener(EndDialogue);
    }
    void Update()
    {
#if UNITY_EDITOR

        if (Input.GetKeyDown(KeyCode.RightArrow))
            NextTextButton();

        if (Input.GetKeyDown(KeyCode.LeftArrow))
            PreviousTextButton();
#endif
    }



    public void SetThings()
    {
        UiObject.SetActive(true);

        SetText();

        nextButton.onClick.RemoveAllListeners();
        nextButton.onClick.AddListener(NextTextButton);
        previousButton.onClick.RemoveAllListeners();
        previousButton.onClick.AddListener(PreviousTextButton);

        StartCoroutine(DisplayText());
    }

    void SetText()
    {
        displayText.text = "";
        if (splited.Length > 0)
        {
            splited = new char[0];
            splited = dialogueManager.GetText().ToCharArray();
        }
        else
            splited = dialogueManager.GetText().ToCharArray();
    }

    void NextTextButton()
    {
        dialogueManager.NextText();
        StopAllCoroutines();
        SetText();
        StartCoroutine(DisplayText());
    }

    void PreviousTextButton()
    {
        dialogueManager.PreviousText();
        StopAllCoroutines();
        SetText();
        StartCoroutine(DisplayText());
    }
    void EndDialogue()
    {
        StopAllCoroutines();
        UiObject.SetActive(false);
    }
    IEnumerator DisplayText()
    {
        int index = 0;
        yield return new WaitForSeconds(0.005f);
        while (index < splited.Length)
        {
            displayText.text += splited[index];
            index++;
            yield return new WaitForSeconds(displayTextDelay);
        }
        yield return null;
    }
}
