using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteBehavior : MonoBehaviour
{
    [SerializeField]
    private float speed = 100f;
    RectTransform rt;
    int index;
    // Start is called before the first frame update
    void Start()
    {
        rt = GetComponent<RectTransform>();
        //StartCoroutine(Reset());
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);
        /*Vector3 posi = Camera.main.WorldToScreenPoint(transform.position);
        Debug.Log(posi.x);
        if (posi.x < Screen.width - 2000)
        {
            DestroyImmediate(this.gameObject);
        }*/

    }
    public void StartBehavior()
    {
        StartCoroutine(Reset());
    }
    IEnumerator Reset()
    {
        yield return new WaitForSeconds(5f);
        RythemMiniGameManager.instance.ResetNote(this.gameObject, index);
        //DestroyImmediate(this.gameObject);
    }

    public void SetIndex(int value)
    {
        index = value;
    }
}
