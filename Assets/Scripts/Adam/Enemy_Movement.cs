using UnityEngine;
using UnityEngine.AI;
public class EnemyMovement : MonoBehaviour
{
    private NavMeshAgent Agent;
    public Transform[] Waypoints;
    private int Index;
    public Vector3 TargetDestination;
    private GameObject Player;
    void Start()
    {
        Agent = GetComponent<NavMeshAgent>();
        Player = GameObject.Find("Player");
        transform.position = Waypoints[Index].position;
        Index = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (!GetComponent<EnemyCombat>().CanSeePlayer)
        {
            TargetDestination = Waypoints[Index].position;
            Agent.destination = TargetDestination;
        }
        
        else
        {
            Agent.destination = Player.transform.position;
        }

        if (Vector3.Distance(TargetDestination, transform.position) < 1f)
        {
            Index++;
        }

        if (Index == Waypoints.Length)
        {
            Index = 0;
        }
    }
}
