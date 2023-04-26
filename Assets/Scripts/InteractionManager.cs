using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;
public class InteractionManager : MonoBehaviour
{
    //DialogueManager dialogueManager;
    [SerializeField]
    LayerMask mask;
    bool inRange;
    public UnityEvent action;

    // Start is called before the first frame update
    void Start()
    {
        inRange = false;
        //dialogueManager = GetComponent<DialogueManager>();
    }
    private void Update()
    {

        if (Input.GetButton("VERDE0") && inRange )
        {
            if (GameManager.instace.GetState() == GameManager.GameState.play)
            {
                Debug.Log("StartDialogue");
                GameManager.instace.SetState(GameManager.GameState.interaction);
                //dialogueManager.StartDialogue();
                action.Invoke();
            }
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
