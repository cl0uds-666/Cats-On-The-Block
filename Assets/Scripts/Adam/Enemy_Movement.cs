using UnityEngine;
using UnityEngine.AI;
public class EnemyMovement : MonoBehaviour
{
    public NavMeshAgent Agent;
    public Transform[] Waypoints;
    private int Index;
    public Vector3 TargetDestination;
    private GameObject Player;
    public GameObject AttackBox;
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
        if (gameObject.CompareTag("Enemy"))
        {
            if (!GetComponent<EnemyCombat>().IsAttacking)
            {
                TargetDestination = Waypoints[Index].position;
                Agent.destination = TargetDestination;
            }

            if (Index == Waypoints.Length)
            {
                Index = 0;
            }
        }

        else
        {
            if (!GetComponent<Melee_Enemy>().IsAttacking)
            {
                TargetDestination = Waypoints[Index].position;
                Agent.destination = TargetDestination;
            }

            else if (AttackBox.GetComponent<Enemy_Attack_Box>().CanMove && !AttackBox.GetComponent<Enemy_Attack_Box>().PlayerCollision)
            {
                Agent.destination = Player.transform.position;
            }
        }
        
        if (Vector3.Distance(TargetDestination, transform.position) < 1f)
        {
            Index++;
        }
    }
}
