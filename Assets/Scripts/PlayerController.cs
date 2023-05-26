using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject player;
    public float jumpForce;
    public float maxGravity;
    public float gravity;

    public bool isGrounded;
    Rigidbody2D rb;

    void Start()
    {
        rb = player.GetComponent<Rigidbody2D>(); 
        isGrounded = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && isGrounded == true) 
        {
            rb.velocity = Vector2.zero;
            rb.AddForce(new Vector2(0, jumpForce));
            isGrounded = false;
        }
        if (Input.GetKey(KeyCode.Space))
        {
            rb.gravityScale = gravity;
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            rb.gravityScale = maxGravity;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Ground")
        {
            isGrounded = true;
        }
        if (collision.tag == "Score")
        {
            GameController.instance.score++;
        }
    }



}
