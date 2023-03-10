using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D myRb;
    public float jumpForce;
    public float fallGravity;
    public float speed;
    float horizontal;
    // Start is called before the first frame update
    void Awake()
    {
        myRb = GetComponent<Rigidbody2D>();
        jumpForce = 300;
        fallGravity = 2;
        speed = 500;
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        myRb.velocity = new Vector2(horizontal * speed * Time.fixedDeltaTime, myRb.velocity.y);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            myRb.AddForce(new Vector2(0, jumpForce));
        }

        if (myRb.velocity.y < 0)
        {
            myRb.gravityScale = fallGravity;
        }
        else
        {
            myRb.gravityScale = 1;
        }
    }
}
