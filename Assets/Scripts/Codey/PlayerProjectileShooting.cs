using UnityEngine;

public class PlayerProjectileShooting : MonoBehaviour
{
    public GameObject bulletPrefab;              // Bullet prefab reference
    public Transform gunBarrel;                  // Shooting point
    public float bulletSpeed = 20f;              // Default bullet speed
    public float fireRate = 0.5f;                // Default fire rate
    public int maxAmmo = 100;                    // Maximum ammo capacity for this weapon
    public int currentAmmo;                      // Current ammo for this weapon

    private float nextFireTime = 0f;

    public delegate void AmmoChanged(float ammoPercentage); // Delegate for ammo bar update
    public event AmmoChanged OnAmmoChanged;

    void Start()
    {
        currentAmmo = maxAmmo;                   // Initialize ammo to max for this weapon
        Debug.Log($"{gameObject.name} initialized with {currentAmmo}/{maxAmmo} ammo.");
        UpdateAmmoUI();                          // Initialize ammo bar
    }

    void Update()
    {
        // Skip logic if this weapon is inactive
        if (!gameObject.activeInHierarchy)
        {
            Debug.Log($"{gameObject.name} is inactive. Skipping Update logic.");
            return;
        }

        // Check for shooting input and cooldown
        if (Input.GetButton("Fire1") && Time.time >= nextFireTime && currentAmmo > 0)
        {
            Debug.Log($"{gameObject.name} is firing. Current ammo: {currentAmmo - 1}/{maxAmmo}");
            Shoot();
            nextFireTime = Time.time + fireRate;
            currentAmmo--;                       // Decrease ammo count
            UpdateAmmoUI();
        }

        // Log if trying to shoot without ammo
        if (Input.GetButton("Fire1") && currentAmmo <= 0)
        {
            Debug.LogWarning($"{gameObject.name} is out of ammo!");
        }
    }

    public void UpdateAmmoUI()
    {
        if (OnAmmoChanged != null)
        {
            float ammoPercentage = (float)currentAmmo / maxAmmo;
            Debug.Log($"{gameObject.name} ammo updated: {currentAmmo}/{maxAmmo} ({ammoPercentage * 100}% full)");
            OnAmmoChanged.Invoke(ammoPercentage);
        }
        else
        {
            Debug.LogWarning("OnAmmoChanged event is null. Ammo UI won't update.");
        }
    }

    void Shoot()
    {
        if (bulletPrefab == null || gunBarrel == null)
        {
            Debug.LogError($"Missing references for {gameObject.name}: BulletPrefab or GunBarrel is not assigned.");
            return;
        }

        if (currentAmmo <= 0)
        {
            Debug.LogWarning($"Cannot shoot: {gameObject.name} has no ammo.");
            return;
        }

        // Instantiate and shoot the bullet
        GameObject bullet = Instantiate(bulletPrefab, gunBarrel.position, gunBarrel.rotation);
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        if (rb == null)
        {
            Debug.LogError("Bullet prefab is missing Rigidbody component!");
            return;
        }

        rb.linearVelocity = gunBarrel.forward * bulletSpeed;
        Debug.Log($"Bullet fired from {gameObject.name} at speed {bulletSpeed}.");

        // Optional: Destroy bullet after a certain time to avoid clutter
        Destroy(bullet, 5f);
    }
}
