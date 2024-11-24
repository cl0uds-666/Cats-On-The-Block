using UnityEngine;

public class WaterSource : MonoBehaviour
{
    private bool playerInRange = false;          // Tracks if the player is in range of the water source
    public int refillAmount = 100;               // Amount of ammo to refill

    private void OnTriggerEnter(Collider other)
    {
        // Check if the player entered the trigger
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
            Debug.Log("Player entered water source area. Press 'R' to reload.");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Check if the player exited the trigger
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
            Debug.Log("Player left water source area.");
        }
    }

    private void Update()
    {
        // Check if the player is in range and presses the reload button
        if (playerInRange && Input.GetKeyDown(KeyCode.R))
        {
            ReloadWeapon();
        }
    }

    private void ReloadWeapon()
    {
        // Find the currently active weapon's PlayerCombat component
        WeaponSwitching weaponSwitching = FindObjectOfType<WeaponSwitching>();

        if (weaponSwitching != null)
        {
            PlayerProjectileShooting activeWeapon = weaponSwitching.GetActiveWeapon();

            if (activeWeapon != null)
            {
                // Get the PlayerCombat component from the active weapon
                PlayerCombat playerCombat = activeWeapon.GetComponent<PlayerCombat>();

                if (playerCombat != null)
                {
                    // Refill ammo using the ReloadAmmo method
                    playerCombat.ReloadAmmo(refillAmount);
                    Debug.Log($"Weapon reloaded with {refillAmount} ammo at water source.");
                }
                else
                {
                    Debug.LogError("PlayerCombat script not found on the active weapon!");
                }
            }
            else
            {
                Debug.LogError("No active weapon found in WeaponSwitching!");
            }
        }
        else
        {
            Debug.LogError("WeaponSwitching script not found in the scene!");
        }
    }
}
