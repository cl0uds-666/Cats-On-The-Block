using UnityEngine;
using System.Collections;

public class Player_melee : MonoBehaviour
{
    public bool Scratch;                          // Flag to trigger attack
    public int Damage;                            // Damage dealt by melee attack
    public float AttackTimer;                     // Attack timer (if needed)
    private GameObject Enemy;                     // Reference to the enemy being attacked
    public float AttackForce;                     // Force applied to push enemy
    private bool PushEnemy;                       // Flag to indicate if enemy should be pushed
    public GameObject Player;                     // Reference to the player GameObject

    private void Update()
    {
        // Handle enemy push logic
        if (PushEnemy && Enemy != null)
        {
            StartCoroutine(Push());
        }
        else if (Enemy != null) // Reset enemy velocity if not pushing
        {
            Rigidbody enemyRb = Enemy.GetComponent<Rigidbody>();
            if (enemyRb != null)
            {
                enemyRb.linearVelocity = Vector3.zero;
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        // Check if the object is an enemy
        if (other.CompareTag("Enemy") || other.CompareTag("Melee Enemy"))
        {
            Enemy = other.gameObject;

            if (Scratch)
            {
                // Apply damage based on the type of enemy
                if (other.CompareTag("Enemy"))
                {
                    EnemyCombat enemyCombat = other.GetComponent<EnemyCombat>();
                    if (enemyCombat != null)
                    {
                        enemyCombat.Health -= Damage;
                        Debug.Log($"Damaged Enemy: {Enemy.name}, Remaining Health: {enemyCombat.Health}");
                    }
                    else
                    {
                        Debug.LogError("EnemyCombat script not found on Enemy!");
                    }
                }
                else if (other.CompareTag("Melee Enemy"))
                {
                    
                    Melee_Enemy meleeEnemy = other.GetComponent<Melee_Enemy>();
                    if (meleeEnemy != null)
                    {
                        meleeEnemy.Health -= Damage;
                        Debug.Log($"Damaged Melee Enemy: {Enemy.name}, Remaining Health: {meleeEnemy.Health}");
                    }
                    else
                    {
                        Debug.LogError("Melee_Enemy script not found on Melee Enemy!");
                    }
                }

                // Enable push and disable scratch for cooldown
                PushEnemy = true;
                Scratch = false;

                if (Player != null)
                {
                    Scratch scratchScript = Player.GetComponent<Scratch>();
                    if (scratchScript != null)
                    {
                        scratchScript.CanScratch = false;
                    }
                    else
                    {
                        Debug.LogError("Scratch script not found on Player!");
                    }
                }
                else
                {
                    Debug.LogError("Player reference is not assigned!");
                }
            }
        }
    }

    private IEnumerator Push()
    {
        if (Enemy != null)
        {
            Rigidbody enemyRb = Enemy.GetComponent<Rigidbody>();
            if (enemyRb != null)
            {
                enemyRb.AddForce(transform.forward * AttackForce, ForceMode.Impulse);
                Debug.Log($"Pushed Enemy: {Enemy.name} with force: {AttackForce}");
            }
            else
            {
                Debug.LogError("Rigidbody not found on Enemy!");
            }
        }

        yield return new WaitForSeconds(0.2f);
        PushEnemy = false;
    }
}
