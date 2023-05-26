using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelectionManager : MonoBehaviour
{
    public GameObject[] levels;
    public GameObject selector;
    int i, index;
    private void Awake()
    {
        i = 0;
        index = 0;
    }
    private void Update()
    {
        //var l = Input.GetAxisRaw("HORIZONTAL0");
        if (Input.GetButtonDown("BRANCO0"))
        {
            Increase();
        }
        if (Input.GetButtonDown("AZUL0"))
        {
            Decrease();
        }

        if (Input.GetButtonDown("VERDE0"))
        {
            levels[index].GetComponent<Button>().onClick.Invoke();
        }

        /*if (Input.GetAxisRaw("HORIZONTAL0") > 0)
        {
            Increase();
        }
        if (Input.GetAxisRaw("HORIZONTAL0") < 0)
        {
            Decrease();
        }*/
    }

    public void Increase()
    {
        index++;
        if (index >= levels.Length)
            index = levels.Length-1;
        Debug.Log(index);
        SetSelectorPosition(index);
    }

    public void Decrease()
    {
        index--;
        if (index <= 0)
            index = 0;
        Debug.Log(index);
        SetSelectorPosition(index);
    }

    void SetSelectorPosition (int index)
    {
        selector.transform.position = levels[index].transform.position;
    }
}
