using System.Collections;
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
    bool RunCouroutine = false;
    public float DetectionRadius;
    private GameObject SecondaryCoverHit;
    void Start()
    {
        
    }

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
                    transform.position = new Vector3(EdgeDetection.transform.position.x - 0.5f * CoverHit.transform.localScale.x, transform.position.y, transform.position.z);

                    if (Physics.SphereCast(transform.position, DetectionRadius, GetComponent<Movement>().MoveDirection, out RaycastHit HitInfo))
                    {
                        if (HitInfo.collider.gameObject != CoverHit && HitInfo.transform.position.x < transform.position.x)
                        {
                            //SecondaryCoverHit = HitInfo.collider.gameObject;
                            //EdgeDetection = SecondaryCoverHit.transform.Find("Edge_Detection");
                        }
                    }
                }

                else if (transform.position.x >= EdgeDetection.transform.position.x + 0.5f * CoverHit.transform.localScale.x)
                {
                    GetComponent<Rigidbody>().linearVelocity = new Vector3(0, GetComponent<Rigidbody>().linearVelocity.y, GetComponent<Rigidbody>().linearVelocity.z);
                    transform.position = new Vector3(EdgeDetection.transform.position.x + 0.5f * CoverHit.transform.localScale.x, transform.position.y, transform.position.z);

                    if (Physics.SphereCast(transform.position, DetectionRadius, GetComponent<Movement>().MoveDirection, out RaycastHit HitInfo))
                    {
                        if (HitInfo.collider.gameObject != CoverHit && HitInfo.transform.position.x > transform.position.x)
                        {
                            //SecondaryCoverHit = HitInfo.collider.gameObject;
                            //EdgeDetection = SecondaryCoverHit.transform.Find("Edge_Detection");
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

                    
                        transform.position = new Vector3(transform.position.x, transform.position.y, EdgeDetection.transform.position.z - 0.5f * CoverHit.transform.localScale.z);
                    
                    

                    if (Physics.SphereCast(transform.position, DetectionRadius, GetComponent<Movement>().MoveDirection, out RaycastHit HitInfo))
                    {
                        if (HitInfo.collider.gameObject != CoverHit && HitInfo.transform.position.z < transform.position.z)
                        {
                            

                            if (Input.GetKeyDown(KeyCode.C))
                            {
                                SecondaryCoverHit = HitInfo.collider.gameObject;
                                EdgeDetection = SecondaryCoverHit.transform.Find("Edge_Detection");
                                GetComponent<Rigidbody>().MovePosition(EdgeDetection.transform.position/* * GetComponent<Movement>().Speed*/);
                            }
                        }
                    }

                    
                }

                else if (transform.position.z >= EdgeDetection.transform.position.z + 0.5f * CoverHit.transform.localScale.z)
                {
                    GetComponent<Rigidbody>().linearVelocity = new Vector3(GetComponent<Rigidbody>().linearVelocity.x, GetComponent<Rigidbody>().linearVelocity.y, 0);
                    transform.position = new Vector3(transform.position.x, transform.position.y, EdgeDetection.transform.position.z + 0.5f * CoverHit.transform.localScale.z);

                    if (Physics.SphereCast(transform.position, DetectionRadius, GetComponent<Movement>().MoveDirection, out RaycastHit HitInfo))
                    {
                        if (HitInfo.collider.gameObject != CoverHit && HitInfo.transform.position.z > transform.position.z)
                        {
                            if (Input.GetKeyDown(KeyCode.C))
                            {
                                SecondaryCoverHit = HitInfo.collider.gameObject;
                                EdgeDetection = SecondaryCoverHit.transform.Find("Edge_Detection");
                                GetComponent<Rigidbody>().MovePosition(transform.position + EdgeDetection.transform.position * GetComponent<Movement>().Speed);
                            }
                        }
                    }
                }

                GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation | RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionY;
            }



            if (Input.GetKeyDown(KeyCode.C) && !RunCouroutine)
            {
                StartCoroutine(ToggleCover());
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
                StartCoroutine(ToggleCover());
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

    IEnumerator ToggleCover()
    {
        RunCouroutine = true;

        if (RunCouroutine)
        {
            if (!InCover)
            {
                InCover = true;
                
            }

            //else
            //{
            //    InCover = false;
            //}
        }

        yield return new WaitForSeconds(0.5f);
        RunCouroutine = false;
    }

    private void OnDrawGizmos()
    {
        if (InCover)
        {
            Gizmos.DrawWireSphere(transform.position, DetectionRadius);
        }
    }
}
