using UnityEngine;
using UnityEngine.AI;
public class NPC_Roam_AI : MonoBehaviour
{
    private NavMeshAgent Agent;
    public Transform[] WayPoints;
    private Vector3 TargetDestination;
    private int Index;
    void Start()
    {
        Agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        TargetDestination = WayPoints[Index].position;
        Agent.destination = TargetDestination;

        if (Vector3.Distance(transform.position, TargetDestination) < 1f)
        {
            Index++;
        }

        if (Index == WayPoints.Length)
        {
            Index = 0;
        }
    }
}
