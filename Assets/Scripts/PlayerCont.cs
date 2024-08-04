using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCont : MonoBehaviour
{
    public float speed = 10.0f;
    public float jumpForce = 5f;
    public float minMicLevel = 0.01f; 
    private Rigidbody2D rb2d;
    private MicrophoneInput micInput;
    private bool isGrounded;
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        micInput = GetComponent<MicrophoneInput>(); 
    }

    void Update()
    {
        float micLevel = micInput.GetMicrophoneLevel();
        if (micLevel > minMicLevel)
        {
            float movementSpeed = micLevel * speed;
            rb2d.velocity = new Vector2(movementSpeed, rb2d.velocity.y);
        }
        else
        {
            rb2d.velocity = new Vector2(0, rb2d.velocity.y); 
        }
        
        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            rb2d.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}
