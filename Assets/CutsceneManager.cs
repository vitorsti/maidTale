using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class CutsceneManager : MonoBehaviour
{
    [SerializeField]
    DialogueManager dialogueManager;
    [Header("---- Debug")]
    [SerializeField]
    private bool beginCutscene;
    [SerializeField]
    private Button buttonMenu;
    [SerializeField]
    private TextMeshProUGUI title;
    CutsceneLoaderContainer data;
    private void OnValidate()
    {
        if (beginCutscene)
        {
            beginCutscene = false;
            dialogueManager.StartDialogue();
        }
    }
    private void Awake()
    {
        data = Resources.Load<CutsceneLoaderContainer>("CutsceneLoaderData");
    }

    private void Update()
    {
        if (Input.GetButtonDown("VERDE0") )
        {
            buttonMenu.GetComponent<Button>().onClick.Invoke();
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        title.text = data.GetTitle();

        dialogueManager.SetAfinityAndDialogueData(data.GetCutsceneToLoadName(),data.GetAfinityToLoadName());
    }
    public void OnBeginScene()
    {
        dialogueManager.StartDialogue();
    }
    IEnumerator StartScene()
    {
        yield return new WaitForSeconds(0.05f);
        dialogueManager.StartDialogue();
    }
    public void OnEndCutScene()
    {
        GameManager.instace.SetState(GameManager.GameState.play);
        //DialogueUiDisplay.
    }
}
