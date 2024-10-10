using System.Collections;
using System.Transactions;
using Unity.VisualScripting;
using UnityEngine;

public class Cover : MonoBehaviour
{
    public float Distance;
    public bool InCover = false;
    GameObject CoverHit;
    Transform EdgeDetection;
    RaycastHit hit;
    bool stop;
    public float HighCast;
    public float LowCast;
    public float DetectionRadius;
    public bool SwitchCover = false;
    public LayerMask CoverLayer;
    private void Update()
    {
        if (InCover)
        {
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
                if (transform.position.x <= EdgeDetection.transform.position.x - 0.5f * CoverHit.transform.localScale.x)
                {
                    GetComponent<Rigidbody>().linearVelocity = new Vector3(0, GetComponent<Rigidbody>().linearVelocity.y, GetComponent<Rigidbody>().linearVelocity.z);

                    if (!SwitchCover)
                    {
                        transform.position = new Vector3(EdgeDetection.transform.position.x - 0.5f * CoverHit.transform.localScale.x, transform.position.y, (EdgeDetection.transform.position.z + CoverHit.transform.localScale.z / 2f) - 0.5f);
                    }

                    if (Physics.SphereCast(transform.position, DetectionRadius, GetComponent<Movement>().MoveDirection, out hit, CoverLayer))
                    {
                        if (hit.collider.gameObject != CoverHit && hit.transform.position.x < transform.position.x)
                        {
                            CoverHit = hit.collider.gameObject;
                            EdgeDetection = CoverHit.transform.Find("Edge_Detection");
                            transform.position = EdgeDetection.transform.position;
                        }
                    }
                }

                else if (transform.position.x >= EdgeDetection.transform.position.x + 0.5f * CoverHit.transform.localScale.x)
                {
                    GetComponent<Rigidbody>().linearVelocity = new Vector3(0, GetComponent<Rigidbody>().linearVelocity.y, GetComponent<Rigidbody>().linearVelocity.z);

                    if (!SwitchCover)
                    {
                        transform.position = new Vector3(EdgeDetection.transform.position.x - 0.5f * CoverHit.transform.localScale.x, transform.position.y, (EdgeDetection.transform.position.z + CoverHit.transform.localScale.z / 2f) + 0.5f);
                    }

                    if (Physics.SphereCast(transform.position, DetectionRadius, GetComponent<Movement>().MoveDirection, out hit, CoverLayer))
                    {
                        if (hit.collider.gameObject != CoverHit && hit.transform.position.x > transform.position.x)
                        {
                            if (Input.GetKeyDown(KeyCode.C))
                            {
                                SwitchCover = true;
                                CoverHit = hit.collider.gameObject;
                                EdgeDetection = CoverHit.transform.Find("Edge_Detection");
                            }

                        }
                    }
                }

                GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezePositionY;
            }

            else
            {
                if (transform.position.z <= EdgeDetection.transform.position.z - 0.5f * CoverHit.transform.localScale.z)
                {
                    GetComponent<Rigidbody>().linearVelocity = new Vector3(GetComponent<Rigidbody>().linearVelocity.x, GetComponent<Rigidbody>().linearVelocity.y, 0);

                    if (!SwitchCover)
                    {
                        //if (hit.normal.x == -1)
                        //{
                            transform.position = new Vector3((EdgeDetection.transform.position.x - CoverHit.transform.localScale.x / 2f) - 0.5f, transform.position.y, EdgeDetection.transform.position.z - 0.5f * CoverHit.transform.localScale.z);
                        //}
                    }

                    if (Physics.SphereCast(transform.position, DetectionRadius, GetComponent<Movement>().MoveDirection, out hit, CoverLayer))
                    {
                        if (hit.collider.gameObject != CoverHit && hit.transform.position.z < transform.position.z)
                        {
                            if (Input.GetKeyDown(KeyCode.C))
                            {
                                SwitchCover = true;
                                CoverHit = hit.collider.gameObject;
                                EdgeDetection = CoverHit.transform.Find("Edge_Detection");
                            }
                        }
                    }

                    
                }

                else if (transform.position.z >= EdgeDetection.transform.position.z + 0.5f * CoverHit.transform.localScale.z)
                {
                    GetComponent<Rigidbody>().linearVelocity = new Vector3(GetComponent<Rigidbody>().linearVelocity.x, GetComponent<Rigidbody>().linearVelocity.y, 0);
                    if (!SwitchCover)
                    {
                        //if (hit.normal.x == -1)
                        //{
                            transform.position = new Vector3((EdgeDetection.transform.position.x - CoverHit.transform.localScale.x / 2f) - 0.5f, transform.position.y, EdgeDetection.transform.position.z + 0.5f * CoverHit.transform.localScale.z);
                        //}
                    }

                    if (Physics.SphereCast(transform.position, DetectionRadius, GetComponent<Movement>().MoveDirection, out hit, CoverLayer))
                    {
                        if (hit.collider.gameObject != CoverHit && hit.transform.position.z > transform.position.z)
                        {
                            if (Input.GetKeyDown(KeyCode.C))
                            {
                                SwitchCover = true;
                                CoverHit = hit.collider.gameObject;
                                EdgeDetection = CoverHit.transform.Find("Edge_Detection");
                                
                            }
                        }
                    }
                }

                GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation | RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionY;
            }

            

            if (Input.GetKeyDown(KeyCode.C))
            {
                ToggleCover();
            }
        }

        else
        {
            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
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

        Debug.DrawRay(new Vector3(transform.position.x, transform.position.y + HighCast, transform.position.z), transform.forward * Distance);
        Debug.DrawRay(new Vector3(transform.position.x, transform.position.y + LowCast, transform.position.z), transform.forward * Distance);
    }

    private void FixedUpdate()
    {
       
        if (SwitchCover)
        {
            print(hit.normal);
            if (hit.normal.z == -1)
            {
                print("1");
                GetComponent<Rigidbody>().MovePosition(transform.position + new Vector3(EdgeDetection.transform.position.x - CoverHit.transform.localScale.x / 2f - 0.5f, transform.position.y, EdgeDetection.transform.position.z - 0.5f * CoverHit.transform.localScale.z) * Time.deltaTime * 0.25f);
            }

            else if (hit.normal.z == 1)
            {
                print("2");
                GetComponent<Rigidbody>().MovePosition(transform.position + new Vector3(EdgeDetection.transform.position.x + CoverHit.transform.localScale.x / 2f + 0.5f, transform.position.y, EdgeDetection.transform.position.z + 0.5f * CoverHit.transform.localScale.z) * Time.deltaTime * 0.25f);
            }

            else if (hit.normal.x == 1)
            {
                print("3");
                GetComponent<Rigidbody>().MovePosition(transform.position + new Vector3(EdgeDetection.transform.position.x + 0.5f * CoverHit.transform.localScale.x, transform.position.y, EdgeDetection.transform.position.z + CoverHit.transform.localScale.z / 2f + 0.5f) * Time.deltaTime * 0.25f);
            }
            else if (hit.normal.x == 1)
            {

                GetComponent<Rigidbody>().MovePosition(transform.position + new Vector3(EdgeDetection.transform.position.x - 0.5f * CoverHit.transform.localScale.x, transform.position.y, EdgeDetection.transform.position.z - CoverHit.transform.localScale.z / 2f - 0.5f) * Time.deltaTime * 0.25f);
            }
        }
    }

    void ToggleCover()
    {
        if (!InCover)
        {
            InCover = true;

        }

        else if (!SwitchCover)
        {
            InCover = false;
        }
    }

    private void OnDrawGizmos()
    {
        if (InCover)
        {
            Gizmos.DrawWireSphere(transform.position, DetectionRadius);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Cover") && InCover && SwitchCover)
        {
            SwitchCover = false;
        }
    }
}
