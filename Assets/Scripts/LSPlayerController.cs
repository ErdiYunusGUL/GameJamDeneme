using UnityEngine;

public class LSPlayerController : MonoBehaviour
{
    private float horizontal;
    private float speed = 8f;
    private float jumpingPower = 10f;
    private bool isFacingRight = true;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;

    [SerializeField] private float groundCheckRadiusGrounded = 0.2f;
    [SerializeField] private float groundCheckRadiusAirborne = 0.1f;

    private bool wasGroundedLastFrame;

    private void Update()
    {
        horizontal = Input.GetAxis("Horizontal");

        if (Input.GetButtonDown("Jump") && isGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
        }

        if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }

        Flip();

        wasGroundedLastFrame = isGrounded();
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
    }

    private bool isGrounded()
    {
        float currentGroundCheckRadius = wasGroundedLastFrame ? groundCheckRadiusGrounded : groundCheckRadiusAirborne;
        bool grounded = Physics2D.OverlapCircle(groundCheck.position, currentGroundCheckRadius, groundLayer);
        Debug.Log("Is Grounded: " + grounded);
        return grounded;
    }

    private void Flip()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }
}
