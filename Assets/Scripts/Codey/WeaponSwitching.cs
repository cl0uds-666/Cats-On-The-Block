using UnityEngine;

public class WeaponSwitching : MonoBehaviour
{
    public GameObject[] weapons;                // Array of weapon GameObjects
    public int currentWeaponIndex = 0;          // Index of the currently selected weapon
    public WaterBar waterBarUI;                 // Reference to the WaterBar UI script (set in Inspector)

    private PlayerProjectileShooting currentShootingScript;

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
        // Keyboard inputs for switching weapons
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SelectWeapon(0);  // Switch to weapon at index 0 (e.g., Pistol)
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SelectWeapon(1);  // Switch to weapon at index 1 (e.g., Tommy Gun)
        }

        // Optional: Cycle through weapons with mouse scroll wheel
        if (Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            currentWeaponIndex = (currentWeaponIndex + 1) % weapons.Length;
            SelectWeapon(currentWeaponIndex);
        }
        else if (Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            currentWeaponIndex = (currentWeaponIndex - 1 + weapons.Length) % weapons.Length;
            SelectWeapon(currentWeaponIndex);
        }

        //// Xbox Controller support for weapon switching:
        //// Left bumper (LB) to switch to previous weapon
        //if (Input.GetButtonDown("Xbox_LB"))
        //{
        //    currentWeaponIndex = (currentWeaponIndex - 1 + weapons.Length) % weapons.Length;
        //    SelectWeapon(currentWeaponIndex);
        //}

        //// Right bumper (RB) to switch to next weapon
        //if (Input.GetButtonDown("Xbox_RB"))
        //{
        //    currentWeaponIndex = (currentWeaponIndex + 1) % weapons.Length;
        //    SelectWeapon(currentWeaponIndex);
        //}

    //    // Optional: D-pad support to cycle through weapons
    //    float dPadHorizontal = Input.GetAxis("DPad_Horizontal");
    //    if (dPadHorizontal > 0f) // D-pad right
    //    {
    //        currentWeaponIndex = (currentWeaponIndex + 1) % weapons.Length;
    //        SelectWeapon(currentWeaponIndex);
    //    }
    //    else if (dPadHorizontal < 0f) // D-pad left
    //    {
    //        currentWeaponIndex = (currentWeaponIndex - 1 + weapons.Length) % weapons.Length;
    //        SelectWeapon(currentWeaponIndex);
    //    }
        }

    void SelectWeapon(int index)
    {
        if (index < 0 || index >= weapons.Length) return;

        // Disable all weapons first
        for (int i = 0; i < weapons.Length; i++)
        {
            weapons[i].SetActive(i == index);
        }

        // Set the new weapon index
        currentWeaponIndex = index;

        // Get the shooting script for the currently selected weapon
        currentShootingScript = weapons[currentWeaponIndex].GetComponent<PlayerProjectileShooting>();

        if (currentShootingScript == null)
        {
            Debug.LogError("PlayerProjectileShooting component not found on weapon: " + weapons[currentWeaponIndex].name);
            return;
        }

        // Unsubscribe the previous weapon from the OnAmmoChanged event and subscribe the new weapon
        if (currentShootingScript != null)
        {
            currentShootingScript.OnAmmoChanged -= waterBarUI.UpdateWaterBar;
        }

        currentShootingScript.OnAmmoChanged += waterBarUI.UpdateWaterBar;
        currentShootingScript.UpdateAmmoUI();    // Update UI immediately with the new weapon's ammo
    }

    // Optionally, add this function if you want to retrieve the current active weapon's shooting script
    public PlayerProjectileShooting GetActiveWeapon()
    {
        return weapons[currentWeaponIndex].GetComponent<PlayerProjectileShooting>();
    }
}
