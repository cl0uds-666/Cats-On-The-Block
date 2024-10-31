using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class Melee_Enemy : MonoBehaviour
{
    public bool IsAttacking;
    public Transform LineOfSightPosition;
    public Transform LineOfSightPosition2;
    public Transform LineOfSightPosition3;
    public Transform LineOfSightPosition4;
    public float Distance;
    private RaycastHit Hit;
    public LayerMask PlayerLayer;
    public Vector3 BoxSize;
    
    void Update()
    {
        if (!IsAttacking)
        {
            if (Physics.BoxCast(transform.position, BoxSize * 0.5f, transform.forward, out Hit, transform.rotation, Distance, PlayerLayer))
            {
                IsAttacking = true;
            }

            else if (Physics.BoxCast(LineOfSightPosition.transform.position, BoxSize * 0.5f, LineOfSightPosition.transform.forward, out Hit, LineOfSightPosition.transform.rotation, Distance, PlayerLayer))
            {
                IsAttacking = true;
            }

            else if (Physics.BoxCast(LineOfSightPosition2.transform.position, BoxSize * 0.5f, LineOfSightPosition2.transform.forward, out Hit, LineOfSightPosition2.transform.rotation, Distance, PlayerLayer))
            {
                IsAttacking = true;
            }

            else if (Physics.BoxCast(LineOfSightPosition3.transform.position, BoxSize * 0.5f, LineOfSightPosition3.transform.forward, out Hit, LineOfSightPosition3.transform.rotation, Distance, PlayerLayer))
            {
                IsAttacking = true;
            }

            else if (Physics.BoxCast(LineOfSightPosition4.transform.position, BoxSize * 0.5f, LineOfSightPosition4.transform.forward, out Hit, LineOfSightPosition4.transform.rotation, Distance, PlayerLayer))
            {
                IsAttacking = true;
            }
        }
    }

    private void OnDrawGizmos()
    {
        Debug.DrawRay(transform.position, transform.forward * Distance);
        Debug.DrawRay(LineOfSightPosition.transform.position, LineOfSightPosition.transform.forward * Distance);
        Debug.DrawRay(LineOfSightPosition2.transform.position, LineOfSightPosition2.transform.forward * Distance);
        Debug.DrawRay(LineOfSightPosition3.transform.position, LineOfSightPosition3.transform.forward * Distance);
        Debug.DrawRay(LineOfSightPosition4.transform.position, LineOfSightPosition4.transform.forward * Distance);
    }
}
