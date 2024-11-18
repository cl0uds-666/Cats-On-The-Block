using UnityEngine;
using UnityEngine.UI;

public class WaterBar : MonoBehaviour
{
    public Image waterFillImage;                // Reference to the water fill image

    private PlayerCombat playerCombat;

    void Start()
    {
        // Find the active weapon's PlayerCombat component
        WeaponSwitching weaponSwitching = FindObjectOfType<WeaponSwitching>();

        if (weaponSwitching != null)
        {
            // Get the active weapon's PlayerProjectileShooting component
            PlayerProjectileShooting activeWeapon = weaponSwitching.GetActiveWeapon();

            if (activeWeapon != null)
            {
                playerCombat = activeWeapon.GetComponent<PlayerCombat>();

                if (playerCombat != null)
                {
                    // Subscribe to the OnAmmoChanged event
                    playerCombat.OnAmmoChanged += UpdateWaterBar;
                    Debug.Log("WaterBar subscribed to PlayerCombat's OnAmmoChanged event.");
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
            Debug.LogError("WeaponSwitching script not found!");
        }
    }

    public void UpdateWaterBar(float ammoPercentage)
    {
        if (waterFillImage != null)
        {
            waterFillImage.fillAmount = ammoPercentage;
        }
        else
        {
            Debug.LogError("Water fill image is not assigned in the inspector!");
        }
    }
}
