using UnityEngine;
using System.Collections.Generic;
public class Enemy_Detection : MonoBehaviour
{
    public List<GameObject> EnemiesInCover;
    public Collider[] AllEnemies;
    public float Radius;
    public LayerMask EnemyLayer;

    private void Update()
    {
        AllEnemies = Physics.OverlapSphere(transform.position, Radius, EnemyLayer);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, Radius);
    }
}
