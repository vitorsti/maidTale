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
    public GameObject imageinteraction;
    public UnityEvent action;

    // Start is called before the first frame update
    void Start()
    {
        inRange = false;
        imageinteraction.SetActive(inRange);
        //dialogueManager = GetComponent<DialogueManager>();
    }
    private void Update()
    {

        if (Input.GetButtonDown("VERDE0") && inRange && GameManager.instace.GetState() == GameManager.GameState.play)
        {
            
                //Debug.Log("StartDialogue");
                //GameManager.instace.SetState(GameManager.GameState.interaction);
                //dialogueManager.StartDialogue();
                action.Invoke();
            
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        inRange = true;
        imageinteraction.SetActive(inRange);
        Debug.Log("enter");

    }

    private void OnTriggerExit2D(Collider2D collision)
    {

        inRange = false;
        imageinteraction.SetActive(inRange);
        Debug.Log("exit");


    }
}
