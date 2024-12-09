using UnityEngine;
using System.Collections;

public class Enemy_Attack_Box : MonoBehaviour
{
    public bool PlayerCollision;
    private bool Scratch;
    public GameObject Player;
    public int Damage;
    public bool CanMove;
    public float AttackTimer;
    public GameObject Enemy;
    public float AttackForce;
    private bool PushPlayer;
    void Start()
    {
        CanMove = true;
    }

    private void Update()
    {
        if (PushPlayer)
        {
            StartCoroutine(Push());
        }

        if (PlayerCollision)
        {
            if (Scratch)
            {
                Player.GetComponent<Player_Stats>().Health -= Damage;
                PushPlayer = true;
                Scratch = false;
            }

            else if (!Scratch && CanMove)
            {
                StartCoroutine(AttackDelay());
            }

            if (!GetComponentInParent<Melee_Enemy>().IsAttacking)
            {
                PlayerCollision = false;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && GetComponentInParent<Melee_Enemy>().IsAttacking)
        {
            PlayerCollision = true;   
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerCollision = false;
        }
    }

    private IEnumerator AttackDelay()
    {
        CanMove = false;
        Enemy.GetComponent<EnemyMovement>().Agent.velocity = Vector3.zero;
        Enemy.GetComponent<EnemyMovement>().Agent.ResetPath();
        Scratch = true;
        yield return new WaitForSeconds(AttackTimer);
        CanMove = true;
    }

    private IEnumerator Push()
    {
        Player.GetComponent<Rigidbody>().AddForce(transform.forward * AttackForce * Time.deltaTime);
        yield return new WaitForSeconds(0.2f);
        PushPlayer = false;
    }
}
