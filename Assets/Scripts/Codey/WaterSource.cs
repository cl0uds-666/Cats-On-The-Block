using UnityEngine;

public class WaterSource : MonoBehaviour
{
    private bool playerInRange = false;           // Tracks if the player is in range of the water source
    public int refillAmount = 100;                // Amount of ammo to refill

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
        // Find the currently active weapon's PlayerProjectileShooting component
        PlayerProjectileShooting currentWeapon = FindObjectOfType<WeaponSwitching>().GetActiveWeapon();

        if (currentWeapon != null)
        {
            // Refill the weapon's ammo to its maximum
            currentWeapon.currentAmmo = currentWeapon.maxAmmo;
            currentWeapon.UpdateAmmoUI();
            Debug.Log("Weapon reloaded at water source.");
        }
    }
}
