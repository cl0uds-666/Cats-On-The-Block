using UnityEngine;
using UnityEngine.InputSystem;

public class Player_Movment_Murray : MonoBehaviour
{
    private Rigidbody rb;
    private Vector2 movement;
    private Vector2 direction;

    public float Speed = 5f;
    public float jumpForce = 5f;  // The force applied for jumping
    public LayerMask groundLayer; // The layer that represents the ground
    public Transform groundCheck; // The transform to check if the player is on the ground
    public float groundCheckRadius = 0.2f; // Radius for ground detection

    private bool isGrounded; // To check if the player is on the ground

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Check if the player is on the ground
        isGrounded = Physics.CheckSphere(groundCheck.position, groundCheckRadius, groundLayer);
    }

    void OnMove(InputValue value)
    {
        movement = value.Get<Vector2>();
    }

    private void FixedUpdate()
    {
        Vector3 moveDirection = new Vector3(movement.x, 0f, movement.y);
        rb.MovePosition(transform.position + moveDirection * Time.deltaTime * Speed);
    }

    void OnJump()
    {
        // Jump if the player is grounded
        if (isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    void OnLook(InputValue value)
    {
        if (value.Get<Vector2>() != Vector2.zero)
        {
            direction = value.Get<Vector2>();
            float angle = Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(new Vector3(0, angle, 0));
        }
    }
}
