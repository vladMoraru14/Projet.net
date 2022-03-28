using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{   
    private Rigidbody2D rb2D;

    public float moveSpeed;
    public float jumpForce;
    private bool isJumping;
    private float moveHor;
    private float moveVer;
    // Start is called before the first frame update
    void Start()
    {
        rb2D = gameObject.GetComponent<Rigidbody2D>();
        //moveSpeed = 0.2f;
        //jumpForce = 2f;
        isJumping = false;
    }

    // Update is called once per frame
    void Update()
    {
        moveHor = Input.GetAxisRaw("Horizontal");
        moveVer = Input.GetAxisRaw("Vertical");
    }

    private void FixedUpdate()
    {
        if(moveHor > 0.1f || moveHor < -0.1f)
        {
            rb2D.AddForce(new Vector2(moveHor * moveSpeed, 0f), ForceMode2D.Impulse);

        }
        if(!isJumping && moveVer > 0.1f )
        {
            rb2D.AddForce(new Vector2(0f, moveVer * jumpForce), ForceMode2D.Impulse);

        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Platform")
        {
            isJumping = false;
        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Platform")
        {
            isJumping = true;
        }
    }

}
