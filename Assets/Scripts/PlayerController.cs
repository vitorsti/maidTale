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
    private Animator anim;
    private SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
    void Awake()
    {
        myRb = GetComponent<Rigidbody2D>();
        //anim = GetComponent<Animator>();
        //spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instace.GetState() == GameManager.GameState.play)
        {
            vertical = Input.GetAxis(/*"Vertical"*/"VERTICAL0");
            horizontal = Input.GetAxis(/*"Horizontal"*/"HORIZONTAL0");
        }

        // myRb.velocity = new Vector2(horizontal * speed * Time.fixedDeltaTime, vertical * speed * Time.fixedDeltaTime);
        /*if (horizontal>0.1f|| horizontal <0.0f )
        {
            anim.SetBool("bWalk", true);
            spriteRenderer.flipX = false;
        } 
  
        if(horizontal == 0 )
        {
            anim.SetBool("bWalk", false);
        }

        if(horizontal< 0.0f)
        {
            anim.SetBool("bWalk", true);
            spriteRenderer.flipX = true;
        }
        if (vertical > 0.1f || vertical < 0.0f)
        {
            anim.SetBool("bWalk", true);
        }*/
    }

    private void FixedUpdate()
    {
        myRb.velocity = new Vector2(horizontal * speed * Time.fixedDeltaTime, vertical * speed * Time.fixedDeltaTime);
    }
}
