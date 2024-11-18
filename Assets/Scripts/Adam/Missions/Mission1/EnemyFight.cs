using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;
using System;
using System.Collections;

public class EnemyFight : MonoBehaviour
{
    public GameObject AttackBox;
    private NavMeshAgent Agent;
    public GameObject Enemy;
    public bool CanLoop = true;
    private void Start()
    {
        Agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if (Vector3.Distance(transform.position, GetComponent<EnemyMovement>().Waypoints[GetComponent<EnemyMovement>().Waypoints.Length].gameObject.transform.position) < 1f)
        {
            print("Stop and attack");

            for (int i = 0; i < GetComponent<EnemyMovement>().Waypoints.Length; i++)
            {
                print(GetComponent<EnemyMovement>().Waypoints[i]);
                GetComponent<EnemyMovement>().Waypoints[i] = null;
            }

            GetComponent<Melee_Enemy>().enabled = true;
            AttackBox.SetActive(true);
            Agent.isStopped = true;
            CanLoop = false;
        }
    }
}
