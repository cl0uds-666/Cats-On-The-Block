using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    private Rigidbody rb;
    public float Speed = 5f;         // Regular walking speed
    public float SprintSpeed = 8f;   // Sprint speed
    public float JumpForce = 5f;
    public float DashTime = 0.2f;
    public Transform Cam;

    private float MoveX;
    private float MoveZ;
    public bool IsSprinting = false;  // Changed from private to public
    public bool IsGrounded;
    public bool IsDashing = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Jump if grounded
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded)
        {
            rb.AddForce(Vector3.up * JumpForce * Time.deltaTime, ForceMode.Impulse);
        }

        // Start dash if grounded, moving, and not already dashing
        if (Input.GetKeyDown(KeyCode.C) && IsGrounded && !IsDashing && (rb.linearVelocity.x != 0 || rb.linearVelocity.z != 0))
        {
            StartCoroutine(Dash());
        }

        // Toggle sprinting based on Left Control key
        if (Input.GetKey(KeyCode.LeftControl))
        {
            IsSprinting = true;
            Debug.Log("Sprinting activated");
        }
        else if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            IsSprinting = false;
            Debug.Log("Sprinting deactivated");
        }
    }

    private void FixedUpdate()
    {
        MoveX = Input.GetAxis("Horizontal");
        MoveZ = Input.GetAxis("Vertical");

        if (IsGrounded && rb.linearVelocity.x > 0 || IsGrounded && rb.linearVelocity.z > 0)
        {
            if (!GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Walking"))
            {
                GetComponent<Animator>().SetInteger("MainState", 1);
            }
        }

        else if (IsGrounded && rb.linearVelocity == Vector3.zero)
        {
            if (!GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Idle"))
            {
                GetComponent<Animator>().SetInteger("MainState", 0);
            }
        }

        Vector3 CamX = Cam.forward;
        Vector3 CamZ = Cam.right;

        CamX.y = 0;
        CamZ.y = 0;
        CamX.Normalize();
        CamZ.Normalize();

        Vector3 ForwardLook = MoveZ * CamX;
        Vector3 HorizontalLook = MoveX * CamZ;
        Vector3 MoveDirection = (ForwardLook + HorizontalLook).normalized;

        float currentSpeed = IsSprinting ? SprintSpeed : Speed;

        rb.linearVelocity = new Vector3(MoveDirection.x * currentSpeed, rb.linearVelocity.y, MoveDirection.z * currentSpeed);// * Time.fixedDeltaTime;

        if (MoveDirection != Vector3.zero && !GetComponent<Cover>().InCover)
        {
            transform.forward = MoveDirection;
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            IsGrounded = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            IsGrounded = false;
        }
    }

    private IEnumerator Dash()
    {
        IsDashing = true;
        yield return new WaitForSeconds(DashTime);
        IsDashing = false;
    }

    void OnCoverDash(InputValue Value)
    {
        Debug.Log("Cover Dash activated");
        if (IsGrounded && !IsDashing && (rb.linearVelocity.x != 0 || rb.linearVelocity.z != 0))
        {
            StartCoroutine(Dash());
        }
    }
}
