using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // movement stuff
    public float moveSpeed;
    public float jumpForce;
    private Rigidbody2D rb; // this is private, so no other scripts can access this
    private SpriteRenderer sprite; // control what way the player is facing

    // animation stuff
    private Animator anim; // control the animations
    public bool walking; // handle the walking animation
    public bool jumping; // handle the jump animation
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetBool("walking", walking); // handles the animator for walking
        anim.SetBool("jumping", jumping); // handles the animator for jumping
        if (Input.GetKey(KeyCode.D)) // going right
        {
            transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
            sprite.flipX = false; // flip the sprite if needed to face right
            walking = true;
        }
        if (Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.A)) // when we release the D or A key, stop walking
        {
            walking = false;
        }
        if(Input.GetKey(KeyCode.A)) // going to the left
        {
            transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
            sprite.flipX = true; // flip the sprite if needed to face left
            walking = true;
        }
        if (Input.GetKeyDown(KeyCode.Space)) // jumping
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode2D.Impulse);
            jumping = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        jumping = false; // whenever we collide with something, jumping will be false
    }
}
