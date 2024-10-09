using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

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

        MoveDirection = ForwardLook + HorizontalLook;

        rb.linearVelocity = new Vector3(MoveDirection.x * Speed, rb.linearVelocity.y, MoveDirection.z * Speed);

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
}
