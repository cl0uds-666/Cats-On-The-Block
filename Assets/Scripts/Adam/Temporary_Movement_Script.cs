using UnityEngine;

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
    private void OnTriggerEnter(Collider Collision)
    {
        if(Collision.gameObject.tag == "ground" && !IsGrounded )
        {
            IsGrounded = true;
        }
    }

    private void OnTriggerExit(Collider Collision)
    {
        if(Collision.gameObject.tag == "ground" && IsGrounded == true)
        {
            IsGrounded = false;
        }


    }

    void Update()
    {
        
        // Jump if grounded
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded || Input.GetKeyDown(KeyCode.Joystick1Button0) && IsGrounded)
        {
            rb.AddForce(Vector3.up * JumpForce);
            Debug.Log("Sprinting activated");
        }
 

        if(Input.GetKeyDown(KeyCode.LeftShift) && IsGrounded || Input.GetKeyDown(KeyCode.Joystick1Button8) && IsGrounded) 
        {
            IsSprinting = true;
        }

        if(Input.GetKeyUp(KeyCode.LeftShift) && IsGrounded || Input.GetKeyUp(KeyCode.Joystick1Button8) && IsGrounded)
        {
            IsSprinting = false;
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
            transform.forward += MoveDirection;
            if(IsSprinting == true)
            {
                 
                transform.forward += MoveDirection * 2;
            }
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
 
}
