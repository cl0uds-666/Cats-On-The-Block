using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class WeaponSwitching : MonoBehaviour
{
    public List<GameObject> weapons;                // Array of weapon GameObjects
    public int currentWeaponIndex = 0;          // Index of the currently selected weapon
    public WaterBar waterBarUI;                 // Reference to the WaterBar UI script (set in Inspector)
    public GameObject WheelImage;
    private PlayerProjectileShooting currentShootingScript;
    private GrenadeThrower currentGrenadeThrower;
    public float WheelTime;

    public PlayerProjectileShooting GetActiveWeapon()
    {
        return weapons[currentWeaponIndex].GetComponent<PlayerProjectileShooting>();
    }

    void Start()
    {
        if (waterBarUI == null)
        {
            Debug.LogError("WaterBar UI is not assigned in the Inspector.");
            return;
        }

        SelectWeapon(currentWeaponIndex);       // Start with the first weapon
    }

    void Update()
    {
        // Number keys to switch weapons
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SelectWeapon(0);  // Switch to weapon at index 0 (e.g., Pistol)
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SelectWeapon(1);  // Switch to weapon at index 1 (e.g., Tommy Gun)
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            SelectWeapon(2);  // Switch to weapon at index 2 (e.g., Grenade)
        }

        // Optional: Cycle through weapons with scroll wheel
        if (Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            currentWeaponIndex = (currentWeaponIndex + 1) % weapons.Count;
            SelectWeapon(currentWeaponIndex);
        }
        else if (Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            currentWeaponIndex = (currentWeaponIndex - 1 + weapons.Count) % weapons.Count;
            SelectWeapon(currentWeaponIndex);
        }

        // Xbox Controller support for weapon switching:
        if (Input.GetButtonDown("Xbox_LB"))
        {
            currentWeaponIndex = (currentWeaponIndex - 1 + weapons.Count) % weapons.Count;
            SelectWeapon(currentWeaponIndex);
        }

        if (Input.GetButtonDown("Xbox_RB"))
        {
            currentWeaponIndex = (currentWeaponIndex + 1) % weapons.Count;
            SelectWeapon(currentWeaponIndex);
        }
    }

    void SelectWeapon(int index)
    {
        StartCoroutine(Wheel());

        if (index < 0 || index >= weapons.Count) return;

        // Disable all weapons first
        for (int i = 0; i < weapons.Count; i++)
        {
            weapons[i].SetActive(i == index);
        }

        // Set the new weapon index
        currentWeaponIndex = index;

        // Check if the new weapon is a projectile weapon
        currentShootingScript = weapons[currentWeaponIndex].GetComponent<PlayerProjectileShooting>();
        if (currentShootingScript != null)
        {
            if (waterBarUI != null)
            {
                // Unsubscribe the previous weapon from the OnAmmoChanged event
                currentShootingScript.OnAmmoChanged -= waterBarUI.UpdateWaterBar;

                // Subscribe the new weapon to the OnAmmoChanged event
                currentShootingScript.OnAmmoChanged += waterBarUI.UpdateWaterBar;

                // Update the ammo UI immediately
                currentShootingScript.UpdateAmmoUI();
            }
            Debug.Log($"Selected projectile weapon: {weapons[currentWeaponIndex].name}");
        }
        else
        {
            Debug.Log($"No projectile script found on weapon: {weapons[currentWeaponIndex].name}");
        }

        // Check if the new weapon is a grenade
        currentGrenadeThrower = weapons[currentWeaponIndex].GetComponent<GrenadeThrower>();
        if (currentGrenadeThrower != null)
        {
            Debug.Log($"Selected grenade: {weapons[currentWeaponIndex].name}");
        }
    }

    private IEnumerator Wheel()
    {
        WheelImage.SetActive(true);
        yield return new WaitForSeconds(WheelTime);
        WheelImage.SetActive(false);
    }
}
