using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    Rigidbody rb;
    public float Speed;
    float MoveX;
    float MoveZ;
    public bool IsGrounded;
    public float JumpForce;
    public Transform Cam;
    public Vector3 MoveDirection;
    public bool IsDashing = false;
    public float DashTime;
    public bool IsSprinting = false;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded)
        {
            rb.AddForce(Vector3.up * JumpForce);
        }

        if (Input.GetKeyDown(KeyCode.C) && IsGrounded && !IsDashing && rb.linearVelocity.x != 0 || Input.GetKeyDown(KeyCode.C) && IsGrounded && !IsDashing && rb.linearVelocity.z != 0)
        {
            StartCoroutine(Dash());
        }

        if (IsDashing)
        {
            print("is dashing");
        }

        else
        {
            print("is not dashing");
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            IsSprinting = true;
            print("is sprinting");
        }

        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            IsSprinting = false;
            print("is not sprinting");
        }
    }

    private void FixedUpdate()
    {
        MoveX = Input.GetAxis("Horizontal");
        MoveZ = Input.GetAxis("Vertical");

        Vector3 CamX = Cam.forward;
        Vector3 CamZ = Cam.right;

        CamX.y = 0;
        CamZ.y = 0;

        Vector3 ForwardLook = MoveZ * CamX;
        Vector3 HorizontalLook = MoveX * CamZ;

        Vector3 MoveDirection = ForwardLook + HorizontalLook;

        rb.linearVelocity = new Vector3(MoveDirection.x * Speed * Time.fixedDeltaTime, rb.linearVelocity.y, MoveDirection.z * Speed * Time.fixedDeltaTime);

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
        print("B");
        if (IsGrounded && !IsDashing && rb.linearVelocity.x != 0 || IsGrounded && !IsDashing && rb.linearVelocity.z != 0)
        {
            StartCoroutine(Dash());
        }
    }
}
