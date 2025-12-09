//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//// Basic 2D player movement script from: https://qookie.games/2d-player-movement/

//public class MyPlayerController : MonoBehaviour
//{
//    public float moveSpeed = 5f;
//    public float jumpForce = 10f;
//    private bool isGrounded;
//    private Rigidbody2D rb;

//    void Start()
//    {
//        rb = GetComponent<Rigidbody2D>();
//    }

//    void Update()
//    {
//        // Handle horizontal movement
//        float moveInput = Input.GetAxis("Horizontal");

//        if (Input.GetKeyDown(KeyCode.LeftShift))
//        {
//            moveSpeed = 7.5f;
//        } else if (Input.GetKeyUp(KeyCode.LeftShift))
//        {
//            moveSpeed = 5f;
//        }

//            rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);

//        // Handle jumping
//        if (Input.GetButtonDown("Jump") && isGrounded)
//        {
//            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
//        }
//    }

//    void OnCollisionEnter2D(Collision2D collision)
//    {
//        // Check if the player is on the ground
//        if (collision.gameObject.CompareTag("Ground"))
//        {
//            isGrounded = true;
//            Debug.Log("isGrounded = " + isGrounded);
//        }
//    }

//    void OnCollisionExit2D(Collision2D collision)
//    {
//        // Check if the player is no longer on the ground
//        if (collision.gameObject.CompareTag("Ground"))
//        {
//            isGrounded = false;
//            Debug.Log("isGrounded = " + isGrounded);
//        }
//    }
//}