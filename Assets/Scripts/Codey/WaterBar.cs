using UnityEngine;
using UnityEngine.UI;

public class WaterBar : MonoBehaviour
{
    public Image waterFillImage;                // Reference to the water fill image

    private PlayerCombat currentPlayerCombat;
    private WeaponSwitching weaponSwitching;

    void Start()
    {
        // Find the WeaponSwitching script
        weaponSwitching = FindObjectOfType<WeaponSwitching>();

        if (weaponSwitching != null)
        {
            UpdateCurrentWeapon(); // Initialize with the current weapon
        }
        else
        {
            Debug.LogError("WeaponSwitching script not found!");
        }
    }

    void Update()
    {
        // Update the active weapon each frame in case of weapon switching
        UpdateCurrentWeapon();
    }

    private void UpdateCurrentWeapon()
    {
        // Get the active weapon's PlayerCombat component
        PlayerProjectileShooting activeWeapon = weaponSwitching.GetActiveWeapon();

        if (activeWeapon != null)
        {
            PlayerCombat newPlayerCombat = activeWeapon.GetComponent<PlayerCombat>();

            // Check if we've switched to a new weapon
            if (newPlayerCombat != currentPlayerCombat)
            {
                // Unsubscribe from the old weapon
                if (currentPlayerCombat != null)
                {
                    currentPlayerCombat.OnAmmoChanged -= UpdateWaterBar;
                }

                // Subscribe to the new weapon
                if (newPlayerCombat != null)
                {
                    currentPlayerCombat = newPlayerCombat;
                    currentPlayerCombat.OnAmmoChanged += UpdateWaterBar;

                    // Update the water bar immediately
                    float ammoPercentage = (float)currentPlayerCombat.currentAmmo / currentPlayerCombat.maxAmmo;
                    UpdateWaterBar(ammoPercentage);
                }
            }
        }
    }

    public void UpdateWaterBar(float ammoPercentage)
    {
        if (waterFillImage != null)
        {
            waterFillImage.fillAmount = ammoPercentage;

            // Make the fill image visible when updating
            if (!waterFillImage.enabled)
            {
                waterFillImage.enabled = true;
            }
        }
        else
        {
            Debug.LogError("Water fill image is not assigned in the inspector!");
        }
    }
}
