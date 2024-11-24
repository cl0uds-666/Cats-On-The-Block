using UnityEngine;

public class GrenadeThrower : MonoBehaviour
{
    [Header("Grenade Settings")]
    public GameObject grenadePrefab;                // Grenade prefab
    public GameObject explosionPrefab;              // Explosion effect prefab
    public Transform throwPoint;                    // Point from which the grenade is thrown
    public float throwForce = 15f;                  // Force applied to the throw
    public float upwardForce = 5f;                  // Upward force for the throw
    public float grenadeLifetime = 5f;              // Time before grenades are destroyed
    public float throwCooldown = 5f;                // Time before next grenade can be thrown

    [Header("Trajectory Settings")]
    public LineRenderer trajectoryLine;             // Line renderer for the trajectory
    public int resolution = 30;                     // Number of points in the trajectory line
    public float timeStep = 0.1f;                   // Time interval between trajectory points

    private GameObject heldGrenade;                 // Reference to the currently held grenade
    private bool isAiming = false;                  // Whether the player is aiming the grenade
    private bool grenadeThrown = false;             // Prevent multiple throws in one cycle
    private float cooldownTimer = 0f;               // Tracks remaining cooldown time

    void Update()
    {
        // Cooldown logic
        if (cooldownTimer > 0f)
        {
            cooldownTimer -= Time.deltaTime;
            Debug.Log($"Cooldown remaining: {Mathf.CeilToInt(cooldownTimer)} seconds");
            return; // Prevent any grenade actions during cooldown
        }

        // Start aiming when Fire2 is held
        if (Input.GetButtonDown("Fire2"))
        {
            StartAiming();
        }

        // Update the trajectory while aiming
        if (Input.GetButton("Fire2") && isAiming)
        {
            ShowTrajectory();
        }

        // Throw the grenade when Fire2 is released
        if (Input.GetButtonUp("Fire2") && isAiming)
        {
            ThrowGrenade();
        }
    }

    void StartAiming()
    {
        if (heldGrenade != null)
        {
            Destroy(heldGrenade);
        }

        isAiming = true;
        grenadeThrown = false;

        heldGrenade = Instantiate(grenadePrefab, throwPoint.position, throwPoint.rotation);
        heldGrenade.transform.parent = throwPoint;

        Rigidbody rb = heldGrenade.GetComponent<Rigidbody>();
        Collider col = heldGrenade.GetComponent<Collider>();
        if (rb != null) rb.isKinematic = true;
        if (col != null) col.enabled = false;

        trajectoryLine.enabled = true;
    }

    void ShowTrajectory()
    {
        if (heldGrenade == null) return;

        trajectoryLine.enabled = true;
        Vector3 velocity = CalculateInitialVelocity();
        Vector3 startPosition = throwPoint.position;

        trajectoryLine.positionCount = resolution;
        for (int i = 0; i < resolution; i++)
        {
            float time = i * timeStep;
            Vector3 point = startPosition + velocity * time + 0.5f * Physics.gravity * time * time;

            if (Physics.Raycast(startPosition, point - startPosition, out RaycastHit hit, (point - startPosition).magnitude))
            {
                trajectoryLine.positionCount = i + 1;
                trajectoryLine.SetPosition(i, hit.point);
                break;
            }

            trajectoryLine.SetPosition(i, point);
        }
    }

    void ThrowGrenade()
    {
        if (heldGrenade == null || grenadeThrown)
        {
            Debug.LogWarning("No grenade to throw or grenade already thrown.");
            return;
        }

        grenadeThrown = true;
        isAiming = false;

        // Disable the trajectory line
        trajectoryLine.enabled = false;

        heldGrenade.transform.parent = null;

        Rigidbody rb = heldGrenade.GetComponent<Rigidbody>();
        Collider col = heldGrenade.GetComponent<Collider>();
        if (rb != null)
        {
            rb.isKinematic = false;
            rb.linearVelocity = CalculateInitialVelocity();
        }
        if (col != null)
        {
            col.enabled = true;
        }

        // Schedule grenade explosion and cleanup
        Invoke(nameof(ExplodeGrenade), grenadeLifetime);
    }

    void ExplodeGrenade()
    {
        if (heldGrenade != null)
        {
            // Instantiate explosion effect at the grenade's position
            if (explosionPrefab != null)
            {
                Instantiate(explosionPrefab, heldGrenade.transform.position, Quaternion.identity);
                Debug.Log("Explosion effect instantiated.");
            }

            Debug.Log("Grenade exploded!");
            Destroy(heldGrenade);
        }

        cooldownTimer = throwCooldown; // Start cooldown
    }

    Vector3 CalculateInitialVelocity()
    {
        return throwPoint.forward * throwForce + Vector3.up * upwardForce;
    }
}
