using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UIElements;

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
    public Transform InitialTarget;

    void Update()
    {
        if (GetComponent<EnemyCombat>().IsAttacking && !InCover && !IsFunctionRunning)
        {
            FindOptimalCover();
        }
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

    private void FindOptimalCover()
    {
        IsFunctionRunning = true;
        DetectedCover = Physics.OverlapSphere(transform.position, CoverDetectionRadius, CoverMask);

        foreach (Collider Cover in DetectedCover)
        {
            

            if (Physics.Raycast(Player.transform.position, Cover.GetComponent<Cover_Points>().Point1.transform.position - Player.transform.position, out Hit, CoverMask))
            {
                print("Optimal1");
                OptimalCover.Add(Cover.GetComponent<Cover_Points>().Point1);
            }

            
            if (Physics.Raycast(Player.transform.position, Cover.GetComponent<Cover_Points>().Point2.transform.position - Player.transform.position, out Hit, CoverMask))
            {
                print("Optimal2");
                OptimalCover.Add(Cover.GetComponent<Cover_Points>().Point2);
            }

            
            if (Physics.Raycast(Player.transform.position, Cover.GetComponent<Cover_Points>().Point3.transform.position - Player.transform.position, out Hit, CoverMask))
            {
                print("Optimal3");
                OptimalCover.Add(Cover.GetComponent<Cover_Points>().Point3);
            }

            
            if (Physics.Raycast(Player.transform.position, Cover.GetComponent<Cover_Points>().Point4.transform.position - Player.transform.position, out Hit, CoverMask))
            {
                print("Optimal4");
                OptimalCover.Add(Cover.GetComponent<Cover_Points>().Point4);
            }

            
            if (Physics.Raycast(Player.transform.position, Cover.GetComponent<Cover_Points>().Point5.transform.position - Player.transform.position, out Hit, CoverMask))
            {
                print("Optimal5");
                OptimalCover.Add(Cover.GetComponent<Cover_Points>().Point5);
            }

            
            if (Physics.Raycast(Player.transform.position, Cover.GetComponent<Cover_Points>().Point6.transform.position - Player.transform.position, out Hit, CoverMask))
            {
                print("Optimal6");
                OptimalCover.Add(Cover.GetComponent<Cover_Points>().Point6);
            }

            
            if (Physics.Raycast(Player.transform.position, Cover.GetComponent<Cover_Points>().Point7.transform.position - Player.transform.position, out Hit, CoverMask))
            {
                print("Optimal7");
                OptimalCover.Add(Cover.GetComponent<Cover_Points>().Point7);
            }

            
            if (Physics.Raycast(Player.transform.position, Cover.GetComponent<Cover_Points>().Point8.transform.position - Player.transform.position, out Hit, CoverMask))
            {
                print("Optimal8");
                OptimalCover.Add(Cover.GetComponent<Cover_Points>().Point8);
            }
        }
        FindTargetCover();
    }

    private void FindTargetCover()
    {
        TargetCover = transform;
        foreach (Transform Cover in OptimalCover)
        {
            if (Vector3.Distance(transform.position, Cover.transform.position) > Vector3.Distance(transform.position, TargetCover.transform.position))
            {
                TargetCover = Cover;
            }
        }

        if (TargetCover != transform)
        {
            transform.position = TargetCover.transform.position;

            InCover = true;
            /*OptimalCover.Clear()*/;
            print("InCover");
        }
        IsFunctionRunning = false;
    }
}
