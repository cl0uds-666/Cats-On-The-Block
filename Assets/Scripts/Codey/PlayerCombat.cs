using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    [Header("Shooting Properties")]
    public GameObject bulletPrefab;              // Bullet prefab reference
    public Transform gunBarrel;                  // Shooting point
    public float bulletSpeed = 20f;              // Default bullet speed
    public float fireRate = 0.5f;                // Default fire rate
    public int maxAmmo = 100;                    // Maximum ammo capacity for this weapon
    public int currentAmmo;                      // Current ammo for this weapon

    [Header("Melee Properties")]
    public GameObject meleeAttackBox;            // Melee attack hitbox
    public int meleeDamage = 20;                 // Melee attack damage
    public float meleeCooldown = 1f;             // Time between melee attacks
    private float meleeCooldownTimer = 0f;

    private float nextFireTime = 0f;

    public delegate void AmmoChanged(float ammoPercentage); // Delegate for ammo bar update
    public event AmmoChanged OnAmmoChanged;

    void Start()
    {
        currentAmmo = maxAmmo;                   // Initialize ammo to max for this weapon
        UpdateAmmoUI();                          // Initialize ammo bar
    }

    void Update()
    {
        HandleShooting();
        HandleMelee();
        HandleReload();
    }

    private void HandleShooting()
    {
        if (Input.GetButton("Fire1") && Time.time >= nextFireTime && currentAmmo > 0)
        {
            Shoot();
            nextFireTime = Time.time + fireRate;
            currentAmmo--;                       // Decrease ammo count
            UpdateAmmoUI();
        }

        if (Input.GetButton("Fire1") && currentAmmo <= 0)
        {
            Debug.LogWarning("Out of ammo! Reload required.");
        }
    }

    private void HandleMelee()
    {
        if (Input.GetButtonDown("Fire2") && meleeCooldownTimer <= 0f) // Right mouse button for melee
        {
            MeleeAttack();
            meleeCooldownTimer = meleeCooldown;
        }

        if (meleeCooldownTimer > 0f)
        {
            meleeCooldownTimer -= Time.deltaTime;
        }
    }

    private void HandleReload()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            ReloadAmmo(maxAmmo); // Reload to full ammo; can be adjusted as needed
        }
    }

    public void ReloadAmmo(int reloadAmount)
    {
        int previousAmmo = currentAmmo;

        // Reload ammo and clamp to max capacity
        currentAmmo = Mathf.Clamp(currentAmmo + reloadAmount, 0, maxAmmo);

        Debug.Log($"Reloaded ammo: {reloadAmount}. Ammo updated from {previousAmmo} to {currentAmmo}/{maxAmmo}.");
        UpdateAmmoUI();
    }

    public void UpdateAmmoUI()
    {
        if (OnAmmoChanged != null)
        {
            float ammoPercentage = (float)currentAmmo / maxAmmo;
            OnAmmoChanged.Invoke(ammoPercentage);
        }
        else
        {
            Debug.LogWarning("OnAmmoChanged event is null. Ammo UI won't update.");
        }
    }

    void Shoot()
    {
        if (currentAmmo <= 0) return;            // Prevent shooting if out of ammo

        if (bulletPrefab == null || gunBarrel == null)
        {
            Debug.LogError("BulletPrefab or GunBarrel is not assigned!");
            return;
        }

        GameObject bullet = Instantiate(bulletPrefab, gunBarrel.position, gunBarrel.rotation);
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.linearVelocity = gunBarrel.forward * bulletSpeed;
            Debug.Log($"Bullet fired from {gameObject.name} at speed {bulletSpeed}.");
        }
        else
        {
            Debug.LogError("Bullet prefab is missing a Rigidbody component!");
        }

        Destroy(bullet, 5f); // Cleanup bullet
    }

    void MeleeAttack()
    {
        if (meleeAttackBox == null)
        {
            Debug.LogError("Melee attack box is not assigned!");
            return;
        }

        Debug.Log("Melee attack executed!");

        // Enable the attack box temporarily
        meleeAttackBox.SetActive(true);

        // Apply damage to targets in melee hitbox
        Collider[] hitColliders = Physics.OverlapBox(
            meleeAttackBox.transform.position,
            meleeAttackBox.transform.localScale / 2,
            meleeAttackBox.transform.rotation
        );

        foreach (var hit in hitColliders)
        {
            if (hit.CompareTag("Enemy"))
            {
                Debug.Log("Hit enemy with melee!");
                EnemyCombat enemy = hit.GetComponent<EnemyCombat>();
                if (enemy != null)
                {
                    enemy.Health -= meleeDamage;
                }
            }
        }

        // Disable the attack box after a short delay
        Invoke(nameof(DisableMeleeBox), 0.1f);
    }

    void DisableMeleeBox()
    {
        meleeAttackBox.SetActive(false);
    }
}
