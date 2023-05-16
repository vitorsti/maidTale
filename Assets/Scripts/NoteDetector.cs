using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteDetector : MonoBehaviour
{
    private bool inside = false;
    [SerializeField]
    GameObject note;
    public static NoteDetector instance;
    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        /*if (Input.GetKeyDown(KeyCode.E) && inside)
        {
            inside = false;
            RythemMiniGameManager.instance.RemoveScore();
            DestroyImmediate(note);
        }*/

        
    }
    public void DestroyNote()
    {
        //DestroyImmediate(note);
        note = null;
    }
    public void SetInside(bool value)
    {
        inside = value;
    }
    public bool GetInside()
    {
        return inside;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Note")
        {
            note = other.gameObject;
            SetInside(true);
            Debug.Log("is note inside:" + GetInside());
        }
    }
   

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Note")
        {
            note = null;
            SetInside(false);
        }
    }

    public GameObject GetNote()
    {
        return note;
    }
}
