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
            //goes in/out of cover if sprinting
            if (GetComponent<Movement>().IsSprinting)
            {
                ToggleCover();
            }


            //this section position and rotation depending on which side of the cover is detected
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

            // these 2 if and else statements prevent the player from going past the boundaries of the cover using the edge detection object, which is in the center of the cover 
            if (stop)
            {
                GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation | RigidbodyConstraints.FreezePositionZ;

                if (transform.position.x <= EdgeDetection.transform.position.x - 0.5f * CoverHit.transform.localScale.x + transform.localScale.x / 2)
                {
                    GetComponent<Rigidbody>().linearVelocity = new Vector3(0, GetComponent<Rigidbody>().linearVelocity.y, GetComponent<Rigidbody>().linearVelocity.z);

                    if (PreviousHit.normal.z == -1)
                    {
                        //sets the position of the player to the edge detection objects position + half of the covers scale, with the players scale added on so they do not peak too far
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
            //freezes the players rotation when in cover so they do not face the wrong way
            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
            Debug.DrawRay(new Vector3(transform.position.x, transform.position.y + HighCast, transform.position.z), transform.forward * Distance);
            Debug.DrawRay(new Vector3(transform.position.x, transform.position.y + LowCast, transform.position.z), transform.forward * Distance);
        }

        // if only the bottom raycast hits cover then it is low cover
        if (!Physics.Raycast(new Vector3(transform.position.x, transform.position.y + HighCast, transform.position.z), transform.forward, out hit, Distance, CoverLayer) && Physics.Raycast(new Vector3(transform.position.x, transform.position.y + LowCast, transform.position.z), transform.forward, out hit, Distance, CoverLayer))
        {
            GetComponent<Movement>().IsDashing = false;
            print("Low Cover");
        }


        //if both raycasts hit cover then its high cover
        else if (Physics.Raycast(new Vector3(transform.position.x, transform.position.y + HighCast, transform.position.z), transform.forward, out hit, Distance, CoverLayer) && Physics.Raycast(new Vector3(transform.position.x, transform.position.y + LowCast, transform.position.z), transform.forward, out hit, Distance, CoverLayer))
        {
            GetComponent<Movement>().IsDashing = false;
            print("High Cover");
        }
    }
    void ToggleCover()// toggles in and out of cover
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
            //goes into/out of cover when dashing
            if (Physics.Raycast(new Vector3(transform.position.x, transform.position.y + HighCast, transform.position.z), transform.forward, out hit, Distance, CoverLayer) || Physics.Raycast(new Vector3(transform.position.x, transform.position.y + LowCast, transform.position.z), transform.forward, out hit, Distance, CoverLayer))
            {
                GetComponent<Movement>().IsDashing = false;
                CoverHit = hit.transform.gameObject;
                EdgeDetection = CoverHit.transform.Find("Edge_Detection");
                ToggleCover();
            }
        }
    }

    

    //the button mapping for both cover and dash
    void OnCoverDash(InputValue Value)
    {
        print("B");
        if (!InCover && GetComponent<Movement>().IsGrounded)
        {
            //go into cover if u press B and the raycast detects cover
            if (Physics.Raycast(new Vector3(transform.position.x, transform.position.y + HighCast, transform.position.z), transform.forward, out hit, Distance, CoverLayer) || Physics.Raycast(new Vector3(transform.position.x, transform.position.y + LowCast, transform.position.z), transform.forward, out hit, Distance, CoverLayer))
            {
                CoverHit = hit.transform.gameObject;
                EdgeDetection = CoverHit.transform.Find("Edge_Detection");
                ToggleCover();
            }
        }

        //goes out of cover
        else if (InCover && GetComponent<Movement>().IsGrounded)
        {
            ToggleCover();
        }

        if (GetComponent<Movement>().CanDash)
        {
            StartCoroutine(GetComponent<Movement>().DashTimer());
        }
    }
}
