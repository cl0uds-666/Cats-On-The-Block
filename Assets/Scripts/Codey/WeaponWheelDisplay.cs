using UnityEngine;
using UnityEngine.UI;

public class WeaponWheelDisplay : MonoBehaviour
{
    public Image weaponImage;                      // UI Image component to display the active weapon
    public Sprite[] weaponSprites;                // Array of Sprites corresponding to each weapon
    public WeaponSwitching weaponSwitching;       // Reference to the WeaponSwitching script

    void Start()
    {
        if (weaponSwitching == null)
        {
            Debug.LogError("WeaponSwitching script is not assigned.");
        }

        if (weaponImage == null)
        {
            Debug.LogError("Weapon Image is not assigned.");
        }

        // Set the initial weapon image
        UpdateWeaponImage();
    }

    void Update()
    {
        // Call UpdateWeaponImage() only when the weapon changes
        UpdateWeaponImage();
    }

    public void UpdateWeaponImage()
    {
        if (weaponSwitching == null || weaponImage == null) return;

        int activeWeaponIndex = weaponSwitching.currentWeaponIndex;
        Debug.Log($"Active Weapon Index: {activeWeaponIndex}");

        if (activeWeaponIndex >= 0 && activeWeaponIndex < weaponSprites.Length)
        {
            weaponImage.sprite = weaponSprites[activeWeaponIndex];
            Debug.Log($"Weapon Sprite Set: {weaponSprites[activeWeaponIndex].name}");
        }
        else
        {
            Debug.LogError("Invalid weapon index or missing sprite for the selected weapon.");
        }
    }

}
