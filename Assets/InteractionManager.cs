using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionManager : MonoBehaviour
{
    DialogueManager dialogueManager;
    [SerializeField]
    LayerMask mask;
    bool inRange;
    // Start is called before the first frame update
    void Start()
    {
        inRange = false;
        dialogueManager = GetComponent<DialogueManager>();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && inRange)
        {
            Debug.Log("StartDialogue");
            dialogueManager.StartDialogue();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        inRange = true;
        Debug.Log("enter");

    }

    private void OnTriggerExit2D(Collider2D collision)
    {

        inRange = false;
        Debug.Log("exit");


    }
}
