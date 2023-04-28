using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneManager : MonoBehaviour
{
    [SerializeField]
    DialogueManager dialogueManager;
    [Header("---- Debug")]
    [SerializeField]
    private bool beginCutscene;
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
        
    }
    // Start is called before the first frame update
    void Start()
    {
        //GameManager.instace.SetState(GameManager.GameState.cutscene);
        //StartCoroutine(StartScene());
        //dialogueManager.StartDialogue();


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
