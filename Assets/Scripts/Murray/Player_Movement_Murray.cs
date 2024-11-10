using UnityEngine;
using UnityEngine.InputSystem;

public class Player_Movment_Murray : MonoBehaviour
{
    private Rigidbody rb;
    private Vector2 movement;
    private Vector2 direction;

    public float Speed = 5f;
    public float sprintSpeed = 8f; // Speed when sprinting
    public float jumpForce = 5f;   // The force applied for jumping
    public LayerMask groundLayer;  // The layer that represents the ground
    public Transform groundCheck;  // The transform to check if the player is on the ground
    public float groundCheckRadius = 0.2f; // Radius for ground detection

    private bool isGrounded; // To check if the player is on the ground
    private float currentSpeed; // To store the current speed

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        currentSpeed = Speed;

        var playerInput = GetComponent<PlayerInput>();
        Debug.Log("PlayerInput Component: " + (playerInput != null ? "Found" : "Not Found"));
    }


    void Update()
    {
        // Check if the player is on the ground
        isGrounded = Physics.CheckSphere(groundCheck.position, groundCheckRadius, groundLayer);
        Debug.Log("IsGrounded: " + isGrounded);
    }

    void OnMove(InputValue value)
    {
        movement = value.Get<Vector2>();
        Debug.Log("OnMove called with movement: " + movement);
    }

    private void FixedUpdate()
    {
        Vector3 moveDirection = new Vector3(movement.x, 0f, movement.y);
        rb.MovePosition(transform.position + moveDirection * Time.fixedDeltaTime * currentSpeed);
        Debug.Log("FixedUpdate Move Position: " + moveDirection * currentSpeed);
    }

    void OnJump()
    {
        if (isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            Debug.Log("Jumped with force: " + jumpForce);
        }
    }

    void OnLook(InputValue value)
    {
        if (value.Get<Vector2>() != Vector2.zero)
        {
            direction = value.Get<Vector2>();
            float angle = Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(new Vector3(0, angle, 0));
            Debug.Log("Rotated to angle: " + angle);
        }
    }

    void OnSprint()
    {
        currentSpeed = sprintSpeed;
        Debug.Log("Sprinting activated, speed: " + sprintSpeed);
    }

    void OnSprintRelease()
    {
        currentSpeed = Speed;
        Debug.Log("Sprinting deactivated, speed: " + Speed);
    }
}
