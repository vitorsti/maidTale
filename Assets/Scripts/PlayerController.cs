using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D myRb;
    [SerializeField]
    private float speed;
    float horizontal;
    float vertical;
    // Start is called before the first frame update
    void Awake()
    {
        myRb = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        vertical = Input.GetAxis(/*"Vertical"*/"VERTICAL0");
        horizontal = Input.GetAxis(/*"Horizontal"*/"HORIZONTAL0");
        myRb.velocity = new Vector2(horizontal * speed * Time.fixedDeltaTime, vertical * speed * Time.fixedDeltaTime);
    }
}
