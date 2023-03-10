using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueUiDisplay : MonoBehaviour
{
    public DialogueManager dialogueManager;
    private char[] splited;
    [SerializeField]
    private TextMeshProUGUI displayText;
    [SerializeField]
    public Button nextButton, previousButton;


    public void SetText()
    {
        if (splited.Length > 0)
            splited = new char[0];
        else
            splited = dialogueManager.GetText().ToCharArray();
    }

    public void SetThings()
    {
        splited = dialogueManager.GetText().ToCharArray();
        nextButton.onClick.RemoveAllListeners();
        nextButton.onClick.AddListener(dialogueManager.NextText);
        previousButton.onClick.RemoveAllListeners();
        previousButton.onClick.AddListener(dialogueManager.PreviousText);

    }
}
