using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteBehavior : MonoBehaviour
{
    [SerializeField]
    private float speed = 100f;
    RectTransform rt;
    // Start is called before the first frame update
    void Start()
    {
        rt = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);
        Vector3 posi = Camera.main.WorldToScreenPoint(transform.position);
        Debug.Log(posi.x);
        if (posi.x < Screen.width-2000)
        {
            DestroyImmediate(this.gameObject);
        }
        
    }
}
