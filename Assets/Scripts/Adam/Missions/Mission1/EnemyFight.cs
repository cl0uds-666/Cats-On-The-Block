using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;
using System;
using System.Collections;

public class EnemyFight : MonoBehaviour
{
    public GameObject AttackBox;
    
    void Update()
    {
        if (Vector3.Distance(transform.position, GetComponent<EnemyMovement>().Waypoints[GetComponent<EnemyMovement>().Waypoints.Length - 1].gameObject.transform.position) < 1f)
        {
            print("Stop and attack");
            GetComponent<Melee_Enemy>().enabled = true;
            AttackBox.SetActive(true);
        }
    }
}
