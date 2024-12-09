using Unity.Cinemachine;
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
    public GameObject NPCText;

    void Start()
    {
        currentAmmo = maxAmmo;                   // Initialize ammo to max for this weapon
        UpdateAmmoUI();                          // Initialize ammo bar
    }

    void Update()
    {
        // Check for shooting input and cooldown
        if (Input.GetAxis("Xbox_RT") > 0 && Time.time >= nextFireTime && currentAmmo > 0 && !NPCText.activeSelf || Input.GetKey(KeyCode.Mouse0) && Time.time >= nextFireTime && currentAmmo > 0 && !NPCText.activeSelf)
        {
            Shoot();
            nextFireTime = Time.time + fireRate;
            currentAmmo--;                       // Decrease ammo count
            UpdateAmmoUI();
        }
    }

    public void UpdateAmmoUI()
    {
        if (OnAmmoChanged != null)
        {
            float ammoPercentage = (float)currentAmmo / maxAmmo;
            OnAmmoChanged.Invoke(ammoPercentage);
        }
    }

    void Shoot()
    {
        if (currentAmmo <= 0) return;            // Prevent shooting if out of ammo

        GameObject bullet = Instantiate(bulletPrefab, gunBarrel.position, gunBarrel.rotation);
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        rb.linearVelocity = gunBarrel.forward * bulletSpeed;
        Destroy(bullet, 5f);
    }
}
