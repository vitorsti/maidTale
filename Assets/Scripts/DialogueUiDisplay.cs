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
    [SerializeField]
    private Image characterLeft, characterRight;
    [SerializeField]
    private Image expressionCharacterLeft, expressionCharacterRight;
    [SerializeField]
    private GameObject choicebuttons;
    [SerializeField]
    private Button goodChoiceButton, badChoiceButton;
    private void Awake()
    {
        UiObject.SetActive(false);
        endDialogueButton.onClick.AddListener(EndDialogue);
    }
    void Update()
    {
#if UNITY_EDITOR

        if (Input.GetKeyDown(KeyCode.RightArrow))
            NextButton();

        if (Input.GetKeyDown(KeyCode.LeftArrow))
            PreviousButton();
#endif
    }



    public void SetThings()
    {
        if (dialogueManager.GetDialogueEnded()) {
            StopAllCoroutines();

            UiObject.SetActive(true);
            SetCharacterImage();
            SetExpression();
            SetColor();
            SetText(dialogueManager.GetTextEnded());

            nextButton.gameObject.SetActive(false);
            previousButton.gameObject.SetActive(false);
            goodChoiceButton.gameObject.SetActive(false);
            badChoiceButton.gameObject.SetActive(false);

            StartCoroutine(DisplayText());
        }
        else
        {
            Debug.Log("passou aqi");
            StopAllCoroutines();

            UiObject.SetActive(true);
            SetCharacterImage();
            SetExpression();
            SetColor();
            SetText(dialogueManager.GetText());

            nextButton.onClick.RemoveAllListeners();
            previousButton.onClick.RemoveAllListeners();
            goodChoiceButton.onClick.RemoveAllListeners();
            badChoiceButton.onClick.RemoveAllListeners();

            nextButton.onClick.AddListener(NextButton);
            previousButton.onClick.AddListener(PreviousButton);
            goodChoiceButton.onClick.AddListener(AddAfinity);
            goodChoiceButton.onClick.AddListener(NextButton);
            badChoiceButton.onClick.AddListener(RemoveAfinity);
            badChoiceButton.onClick.AddListener(NextButton);

            nextButton.gameObject.SetActive(true);
            previousButton.gameObject.SetActive(true);

            ChoiceOption();



            StartCoroutine(DisplayText());
        }
    }

    void SetText(string text)
    {
        displayText.text = "";
        //if (dialogueManager.GetDialogueEnded()) {
       
            if (splited.Length > 0)
            {
                splited = new char[0];
                splited = text.ToCharArray();//dialogueManager.GetTextEnded().ToCharArray();
            }
            else
                splited = text.ToCharArray();//dialogueManager.GetTextEnded().ToCharArray();
                                             //}
                                             //else
                                             //{
       

        //if (splited.Length > 0)
        // {
        // splited = new char[0];
        // splited = dialogueManager.GetText().ToCharArray();
        //}
        // else
        // splited = dialogueManager.GetText().ToCharArray();
        //}
    }

    void SetColor()
    {
        if (characterLeft != null)
            characterLeft.color = dialogueManager.GetColor(0);
        if (characterRight != null)
            characterRight.color = dialogueManager.GetColor(1);

    }
    void SetCharacterImage()
    {
        if (characterLeft != null)
            characterLeft.sprite = dialogueManager.GetCharacterSprite1();
        if (characterRight != null)
            characterRight.sprite = dialogueManager.GetCharacterSprite2();
    }

    void SetExpression()
    {
        if (expressionCharacterLeft != null)
            expressionCharacterLeft.sprite = dialogueManager.GetExpression(0);
        if (expressionCharacterRight != null)
            expressionCharacterRight.sprite = dialogueManager.GetExpression(1);
        //mooooooooooooooooooooooooooooooooooooreee
        //amogus
    }
    void NextButton()
    {
        dialogueManager.NextText();
        ChoiceOption();
        StopAllCoroutines();
        SetCharacterImage();
        SetExpression();
        SetColor();
        SetText(dialogueManager.GetText());
        StartCoroutine(DisplayText());
    }

    void PreviousButton()
    {       
        dialogueManager.PreviousText();
        ChoiceOption();
        StopAllCoroutines();
        SetCharacterImage();
        SetExpression();
        SetColor();
        SetText(dialogueManager.GetText());
        StartCoroutine(DisplayText());
    }

    void AddAfinity()
    {
        dialogueManager.AddAfinity();
    }
    void RemoveAfinity()
    {
        dialogueManager.RemoveAfinity();
    }

    void EndDialogue()
    {
        GameManager.instace.SetState(GameManager.GameState.play);
        dialogueManager = null;
        StopAllCoroutines();
        UiObject.SetActive(false);
    }

    void ChoiceOption()
    {
        if(dialogueManager.GetHasChoice())
        {

            choicebuttons.SetActive(true);
            goodChoiceButton.GetComponentInChildren<TextMeshProUGUI>().text = dialogueManager.GetGoodChoice();
            badChoiceButton.GetComponentInChildren<TextMeshProUGUI>().text = dialogueManager.GetBadChoice();
            nextButton.gameObject.SetActive(false);
            previousButton.gameObject.SetActive(false);
        }
        else
        {
            choicebuttons.SetActive(false);
            nextButton.gameObject.SetActive(true);
            previousButton.gameObject.SetActive(true);
        }
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

