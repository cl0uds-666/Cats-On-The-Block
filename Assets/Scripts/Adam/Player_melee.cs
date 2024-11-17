using UnityEngine;
using System.Collections;
using UnityEngine.InputSystem;

public class Player_melee : MonoBehaviour
{
    public bool Scratch;
    public int Damage;
    public float AttackTimer;
    private GameObject Enemy;
    public float AttackForce;
    private bool PushEnemy;
    public GameObject Player;

    private void Update()
    {
        if (PushEnemy)
        {
            StartCoroutine(Push());
        }

        else
        {
            Enemy.GetComponent<Rigidbody>().linearVelocity = Vector3.zero;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Enemy") || other.CompareTag("Melee Enemy"))
        {
            Enemy = other.gameObject;

            if (Scratch)
            {
                if (other.CompareTag("Enemy"))
                {
                    other.GetComponent<EnemyCombat>().Health -= Damage;
                }

                else
                {
                    other.GetComponent<Melee_Enemy>().Health -= Damage;
                }

                PushEnemy = true;
                Player.GetComponent<Scratch>().CanScratch = false;
                Scratch = false;
            }
        }
    }

    private IEnumerator Push()
    {
        Enemy.GetComponent<Rigidbody>().AddForce(transform.forward * AttackForce * Time.deltaTime);
        yield return new WaitForSeconds(0.2f);
        PushEnemy = false;
    }
}
