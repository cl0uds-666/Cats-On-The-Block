using UnityEngine;
using UnityEngine.InputSystem;

public class Cover : MonoBehaviour
{
    public float Distance;
    public bool InCover = false;
    GameObject CoverHit;
    public Transform EdgeDetection;
    RaycastHit hit;
    RaycastHit PreviousHit;
    bool stop;
    public float HighCast;
    public float LowCast;
    public LayerMask CoverLayer;
    private void Update()
    {
        if (InCover)
        {
            if (GetComponent<Movement>().IsSprinting)
            {
                ToggleCover();
            }

            if (GetComponent<Movement>().IsDashing)
            {
                ToggleCover();
            }

            if (hit.normal.z == -1)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, (EdgeDetection.transform.position.z - CoverHit.transform.localScale.z / 2f) - 0.5f);
                transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, 180, transform.rotation.eulerAngles.z);
            }

            else if (hit.normal.z == 1)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, (EdgeDetection.transform.position.z + CoverHit.transform.localScale.z / 2f) + 0.5f);
                transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, 0, transform.rotation.eulerAngles.z);
            }

            if (hit.normal.x == 1)
            {
                transform.position = new Vector3((EdgeDetection.transform.position.x + CoverHit.transform.localScale.x / 2f) + 0.5f, transform.position.y, transform.position.z);
                transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, 90, transform.rotation.eulerAngles.z);
            }

            else if (hit.normal.x == -1)
            {
                transform.position = new Vector3((EdgeDetection.transform.position.x - CoverHit.transform.localScale.x / 2f) - 0.5f, transform.position.y, transform.position.z);
                transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, -90, transform.rotation.eulerAngles.z);
            }

            if (hit.normal.z == 1 || hit.normal.z == -1)
            {
                stop = true;
            }
            else if (hit.normal.x == 1 || hit.normal.x == -1)
            {
                stop = false;
            }
            if (stop)
            {
                GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation | RigidbodyConstraints.FreezePositionZ;

                if (transform.position.x <= EdgeDetection.transform.position.x - 0.5f * CoverHit.transform.localScale.x + transform.localScale.x / 2)
                {
                    GetComponent<Rigidbody>().linearVelocity = new Vector3(0, GetComponent<Rigidbody>().linearVelocity.y, GetComponent<Rigidbody>().linearVelocity.z);
                    
                    if (PreviousHit.normal.z == -1)
                    {
                        transform.position = new Vector3(EdgeDetection.transform.position.x - 0.5f * CoverHit.transform.localScale.x + transform.localScale.x / 2, transform.position.y, (EdgeDetection.transform.position.z - CoverHit.transform.localScale.z / 2f) - 0.5f);
                    }

                    else if (PreviousHit.normal.z == 1)
                    {
                        transform.position = new Vector3(EdgeDetection.transform.position.x - 0.5f * CoverHit.transform.localScale.x + transform.localScale.x / 2, transform.position.y, (EdgeDetection.transform.position.z + CoverHit.transform.localScale.z / 2f) + 0.5f);
                    }
                }

                else if (transform.position.x >= EdgeDetection.transform.position.x + 0.5f * CoverHit.transform.localScale.x - transform.localScale.x / 2)
                {
                    GetComponent<Rigidbody>().linearVelocity = new Vector3(0, GetComponent<Rigidbody>().linearVelocity.y, GetComponent<Rigidbody>().linearVelocity.z);

                    if (PreviousHit.normal.z == -1)
                    {
                        transform.position = new Vector3(EdgeDetection.transform.position.x + 0.5f * CoverHit.transform.localScale.x - transform.localScale.x / 2, transform.position.y, (EdgeDetection.transform.position.z - CoverHit.transform.localScale.z / 2f) - 0.5f);
                    }

                    else if (PreviousHit.normal.z == 1)
                    {
                        transform.position = new Vector3(EdgeDetection.transform.position.x + 0.5f * CoverHit.transform.localScale.x - transform.localScale.x / 2, transform.position.y, (EdgeDetection.transform.position.z + CoverHit.transform.localScale.z / 2f) + 0.5f);
                    }
                }
            }

            else
            {
                GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation | RigidbodyConstraints.FreezePositionX;
                if (transform.position.z <= EdgeDetection.transform.position.z - 0.5f * CoverHit.transform.localScale.z + transform.localScale.z / 2)
                {
                    GetComponent<Rigidbody>().linearVelocity = new Vector3(GetComponent<Rigidbody>().linearVelocity.x, GetComponent<Rigidbody>().linearVelocity.y, 0);

                    if (PreviousHit.normal.x == -1)
                    {
                        transform.position = new Vector3((EdgeDetection.transform.position.x - CoverHit.transform.localScale.x / 2f) - 0.5f, transform.position.y, EdgeDetection.transform.position.z - 0.5f * CoverHit.transform.localScale.z + transform.localScale.z / 2);
                    }

                    else if (PreviousHit.normal.x == 1)
                    {
                        transform.position = new Vector3((EdgeDetection.transform.position.x + CoverHit.transform.localScale.x / 2f) + 0.5f, transform.position.y, EdgeDetection.transform.position.z - 0.5f * CoverHit.transform.localScale.z + transform.localScale.z / 2);
                    }
                }

                else if (transform.position.z >= EdgeDetection.transform.position.z + 0.5f * CoverHit.transform.localScale.z - transform.localScale.z / 2)
                {
                    GetComponent<Rigidbody>().linearVelocity = new Vector3(GetComponent<Rigidbody>().linearVelocity.x, GetComponent<Rigidbody>().linearVelocity.y, 0);

                    if (PreviousHit.normal.x == -1)
                    {
                        transform.position = new Vector3((EdgeDetection.transform.position.x - CoverHit.transform.localScale.x / 2f) - 0.5f, transform.position.y, EdgeDetection.transform.position.z + 0.5f * CoverHit.transform.localScale.z - transform.localScale.z / 2);
                    }

                    else if (PreviousHit.normal.x == 1)
                    {
                        transform.position = new Vector3((EdgeDetection.transform.position.x + CoverHit.transform.localScale.x / 2f) + 0.5f, transform.position.y, EdgeDetection.transform.position.z + 0.5f * CoverHit.transform.localScale.z - transform.localScale.z / 2);
                    }
                }
            }
        }

        else
        {
            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
            Debug.DrawRay(new Vector3(transform.position.x, transform.position.y + HighCast, transform.position.z), transform.forward * Distance);
            Debug.DrawRay(new Vector3(transform.position.x, transform.position.y + LowCast, transform.position.z), transform.forward * Distance);
        }

        if (Input.GetKeyDown(KeyCode.C) && !InCover && GetComponent<Movement>().IsGrounded)
        {
            if (Physics.Raycast(new Vector3(transform.position.x, HighCast, transform.position.z), transform.forward, out hit, Distance) || Physics.Raycast(new Vector3(transform.position.x, LowCast, transform.position.z), transform.forward, out hit, Distance))
            {
                CoverHit = hit.transform.gameObject;
                EdgeDetection = CoverHit.transform.Find("Edge_Detection");
                ToggleCover();
            }
        }

        if (!Physics.Raycast(new Vector3(transform.position.x, transform.position.y + HighCast, transform.position.z), transform.forward, out hit, Distance) && Physics.Raycast(new Vector3(transform.position.x, transform.position.y + LowCast, transform.position.z), transform.forward, out hit, Distance))
        {
            print("Low Cover");
        }

        else if (Physics.Raycast(new Vector3(transform.position.x, transform.position.y + HighCast, transform.position.z), transform.forward, out hit, Distance) && Physics.Raycast(new Vector3(transform.position.x, transform.position.y + LowCast, transform.position.z), transform.forward, out hit, Distance))
        {
            print("High Cover");
        }
    }
    void ToggleCover()
    {
        if (!InCover)
        {
            PreviousHit = hit;
            InCover = true;
        }

        else
        {
            InCover = false;
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Cover") && GetComponent<Movement>().IsDashing)
        {
            if (Physics.Raycast(new Vector3(transform.position.x, HighCast, transform.position.z), transform.forward, out hit, Distance) || Physics.Raycast(new Vector3(transform.position.x, LowCast, transform.position.z), transform.forward, out hit, Distance))
            {
                GetComponent<Movement>().IsDashing = false;
                CoverHit = hit.transform.gameObject;
                EdgeDetection = CoverHit.transform.Find("Edge_Detection");
                ToggleCover();
            }
        }
    }

    void OnCoverDash(InputValue Value)
    {
        print("B");
        if (!InCover && GetComponent<Movement>().IsGrounded)
        {
            if (Physics.Raycast(new Vector3(transform.position.x, HighCast, transform.position.z), transform.forward, out hit, Distance) || Physics.Raycast(new Vector3(transform.position.x, LowCast, transform.position.z), transform.forward, out hit, Distance))
            {
                CoverHit = hit.transform.gameObject;
                EdgeDetection = CoverHit.transform.Find("Edge_Detection");
                ToggleCover();
            }
        }

        else if (InCover && GetComponent<Movement>().IsGrounded)
        {
            ToggleCover();
        }
    }
}
