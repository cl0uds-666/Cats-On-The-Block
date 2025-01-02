using UnityEngine;

public class PlayerRaycastShooting : MonoBehaviour
{
    public Transform gunBarrel;             // The point from where the raycast originates
    public float shootingRange = 100f;      // Maximum range of the raycast
    public float fireRate = 0.5f;           // Time between shots
    public LayerMask targetLayer;           // Layer mask to detect target objects

    private float nextFireTime = 0f;

    void Update()
    {
        // Check for shooting input and cooldown
        if (Input.GetButtonDown("Fire1") && Time.time >= nextFireTime)
        {
            Shoot();
            nextFireTime = Time.time + fireRate;
            Debug.Log("Shooting");
        }
    }

    void Shoot()
    {
        // Raycast from gun barrel forward
        RaycastHit hit;
        if (Physics.Raycast(gunBarrel.position, gunBarrel.forward, out hit, shootingRange, targetLayer))
        {
            Debug.Log("Hit: " + hit.collider.name);

            // Apply damage if the hit object has a health component
            //Player_Stats targetStats = hit.collider.GetComponent<Player_Stats>();
            //if (targetStats != null)
            //{
            //    targetStats.Health -= 10;  // Apply damage to the target
            //}

        }
        else
        {
            Debug.Log("No hit detected within range.");
        }

        // Draw debug ray in Scene view to visualize ray direction
        Debug.DrawRay(gunBarrel.position, gunBarrel.forward * shootingRange, Color.red, 1f);
    }
}
