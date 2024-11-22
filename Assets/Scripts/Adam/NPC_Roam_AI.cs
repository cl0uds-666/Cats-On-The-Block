using UnityEngine;
using UnityEngine.AI;
public class NPC_Roam_AI : MonoBehaviour
{
    private NavMeshAgent Agent;
    public Transform[] WayPoints;
    private Vector3 TargetDestination;
    private int Index;
    public GameObject TutorialNPC;
    private GameObject Player;
    void Start()
    {
        Agent = GetComponent<NavMeshAgent>();
        Player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (Index < 8)
        {
            TargetDestination = WayPoints[Index].position;
            Agent.destination = TargetDestination;
        }
        
        if (gameObject != TutorialNPC)
        {
            if (Vector3.Distance(transform.position, TargetDestination) < 1)
            {
                Index++;
            }
        }

        else
        {
            if (Index < 8)
            {
                if (Vector3.Distance(transform.position, TargetDestination) < 1)
                {
                    Index++;
                }
            }
            
            else
            {
                if (Vector3.Distance(transform.position, Player.transform.position) < 10)
                {
                    transform.LookAt(new Vector3(Player.transform.position.x, transform.position.y, Player.transform.position.z));
                }
            }
        }

        if (Index == WayPoints.Length && gameObject != TutorialNPC)
        {
            Index = 0;
        }
    }
}
