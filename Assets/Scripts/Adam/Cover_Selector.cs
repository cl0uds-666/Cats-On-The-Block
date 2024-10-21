using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UIElements;
using UnityEngine.AI;
using System;

public class Cover_Selector : MonoBehaviour
{
    public float CoverDetectionRadius;
    public LayerMask CoverMask;
    public Collider[] DetectedCover;
    public List<Transform> OptimalCover;
    public bool InCover;
    public GameObject Player;
    private RaycastHit Hit;
    private Transform TargetCover;
    private bool IsFunctionRunning;

    void Update()
    {
        if (GetComponent<EnemyCombat>().IsAttacking && !InCover && !IsFunctionRunning)
        {
            FindOptimalCover();
        }

        if (Vector3.Distance(GetComponent<NavMeshAgent>().destination, transform.position) < 1.1f && GetComponent<EnemyCombat>().IsAttacking && OptimalCover.Capacity > 0)
        {
            InCover = true;
            OptimalCover.Clear();
            print("InCover");
            IsFunctionRunning = false;
        }

        if (InCover)
        {
            if (TargetCover.name == "Point1" || TargetCover.name == "Point3")
            {
                transform.localRotation = Quaternion.Euler(0f, -90f, 0f);
            }

            else if (TargetCover.name == "Point2" || TargetCover.name == "Point4")
            {
                transform.localRotation = Quaternion.Euler(0f, 90f, 0f);
            }

            else if (TargetCover.name == "Point5" || TargetCover.name == "Point7")
            {
                transform.localRotation = Quaternion.Euler(0f, 0f, 0f);
            }

            else if (TargetCover.name == "Point6" || TargetCover.name == "Point8")
            {
                transform.localRotation = Quaternion.Euler(0f, -180f, 0f);
            }
        }
    }

    private void FindOptimalCover()
    {
        
        IsFunctionRunning = true;
        DetectedCover = Physics.OverlapSphere(transform.position, CoverDetectionRadius, CoverMask);

        foreach (Collider Cover in DetectedCover)
        {
            if (Physics.Raycast(Player.transform.position, Cover.GetComponent<Cover_Points>().Point1.transform.position - Player.transform.position, out Hit, 500f, CoverMask))
            {
                print("Optimal1");
                OptimalCover.Add(Cover.GetComponent<Cover_Points>().Point1);
            }

            
            if (Physics.Raycast(Player.transform.position, Cover.GetComponent<Cover_Points>().Point2.transform.position - Player.transform.position, out Hit, 500f, CoverMask))
            {
                print("Optimal2");
                OptimalCover.Add(Cover.GetComponent<Cover_Points>().Point2);
            }

            
            if (Physics.Raycast(Player.transform.position, Cover.GetComponent<Cover_Points>().Point3.transform.position - Player.transform.position, out Hit, 500f, CoverMask))
            {
                print("Optimal3");
                OptimalCover.Add(Cover.GetComponent<Cover_Points>().Point3);
            }

            
            if (Physics.Raycast(Player.transform.position, Cover.GetComponent<Cover_Points>().Point4.transform.position - Player.transform.position, out Hit, 500f, CoverMask))
            {
                print("Optimal4");
                OptimalCover.Add(Cover.GetComponent<Cover_Points>().Point4);
            }

            
            if (Physics.Raycast(Player.transform.position, Cover.GetComponent<Cover_Points>().Point5.transform.position - Player.transform.position, out Hit, 500f, CoverMask))
            {
                print("Optimal5");
                OptimalCover.Add(Cover.GetComponent<Cover_Points>().Point5);
            }

            
            if (Physics.Raycast(Player.transform.position, Cover.GetComponent<Cover_Points>().Point6.transform.position - Player.transform.position, out Hit, 500f, CoverMask))
            {
                print("Optimal6");
                OptimalCover.Add(Cover.GetComponent<Cover_Points>().Point6);
            }

            
            if (Physics.Raycast(Player.transform.position, Cover.GetComponent<Cover_Points>().Point7.transform.position - Player.transform.position, out Hit, 500f, CoverMask))
            {
                print("Optimal7");
                OptimalCover.Add(Cover.GetComponent<Cover_Points>().Point7);
            }

            if (Physics.Raycast(Player.transform.position, Cover.GetComponent<Cover_Points>().Point8.transform.position - Player.transform.position, out Hit, 500f, CoverMask))
            {
                print("Optimal8");
                OptimalCover.Add(Cover.GetComponent<Cover_Points>().Point8);
            }
        }

        if (OptimalCover.Capacity > 0)
        {
            FindTargetCover();
        }
    }

    private void FindTargetCover()
    {
        TargetCover = OptimalCover[0];
        foreach (Transform Cover in OptimalCover)
        {
            if (Vector3.Distance(Player.transform.position, Cover.transform.position) > Vector3.Distance(Player.transform.position, TargetCover.transform.position))
            {
                TargetCover = Cover;
            }
        }

        GetComponent<NavMeshAgent>().destination = TargetCover.transform.position;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, CoverDetectionRadius);
        if (GetComponent<EnemyCombat>().IsAttacking)
        {
            Debug.DrawRay(Player.transform.position, TargetCover.transform.position - Player.transform.position);
        }
    }
}
