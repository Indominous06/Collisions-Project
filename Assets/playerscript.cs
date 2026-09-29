using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerScript : MonoBehaviour
{
    Rigidbody2D rb;
    PlayerInput pi;

    public float speed;
    public float jumpSpeed;

    // Private property for detecting if on the "ground" or not.
    bool onGround = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        pi = GetComponent<PlayerInput>();
    }

    void Update()
    {
        Debug.Log(onGround);
        InputAction moveAction = pi.actions["Move"];

        Vector2 movementAmount = moveAction.ReadValue<Vector2>();

        // Set the left/right (X) velocity, but keep the current up/down (Y) velocity.
        rb.linearVelocity = new Vector2(movementAmount.x * speed, rb.linearVelocity.y);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject go = collision.gameObject;

        if (go.tag == "Ground")
        {
            onGround = true;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        GameObject go = collision.gameObject;

        if (go.tag == "Ground")
        {
            onGround = false;
        }
    }

    void OnJump()
    {
        if (onGround == true)
        {
            // Keep left/right velocity, set up velocity to the jump speed.
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpSpeed);
        }
    }
}
