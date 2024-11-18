using UnityEngine;

public class GrenadeThrower : MonoBehaviour
{
    [Header("Grenade Settings")]
    public GameObject grenadePrefab;                // Grenade prefab
    public Transform throwPoint;                    // Point from which the grenade is thrown
    public float throwForce = 15f;                  // Force applied to throw the grenade
    public float upwardForce = 5f;                  // Upward force for the throw

    [Header("Trajectory Settings")]
    public LineRenderer trajectoryLine;             // Line renderer for the trajectory
    public int resolution = 30;                     // Number of points in the trajectory line
    public float timeStep = 0.1f;                   // Time interval between trajectory points

    [Header("Physics")]
    public LayerMask collisionMask;                 // Layer mask for detecting collisions

    void Update()
    {
        // Update trajectory visualization
        if (Input.GetButton("Fire2")) // Right mouse button to aim grenade
        {
            ShowTrajectory();
        }

        // Throw the grenade
        if (Input.GetButtonUp("Fire2"))
        {
            ThrowGrenade();
            trajectoryLine.enabled = false; // Disable the trajectory line after throwing
        }
    }

    void ShowTrajectory()
    {
        trajectoryLine.enabled = true;

        Vector3 velocity = CalculateInitialVelocity();
        Vector3 startPosition = throwPoint.position;

        trajectoryLine.positionCount = resolution;
        for (int i = 0; i < resolution; i++)
        {
            float time = i * timeStep;
            Vector3 point = startPosition + velocity * time + 0.5f * Physics.gravity * time * time;

            // Check for collision
            if (Physics.Raycast(startPosition, point - startPosition, out RaycastHit hit, (point - startPosition).magnitude, collisionMask))
            {
                trajectoryLine.positionCount = i + 1; // Limit trajectory to collision point
                trajectoryLine.SetPosition(i, hit.point);
                break;
            }

            trajectoryLine.SetPosition(i, point);
        }
    }

    void ThrowGrenade()
    {
        GameObject grenade = Instantiate(grenadePrefab, throwPoint.position, Quaternion.identity);
        Rigidbody rb = grenade.GetComponent<Rigidbody>();
        if (rb != null)
        {
            Vector3 velocity = CalculateInitialVelocity();
            rb.linearVelocity = velocity;
        }
    }

    Vector3 CalculateInitialVelocity()
    {
        Vector3 forward = throwPoint.forward * throwForce;
        Vector3 upward = Vector3.up * upwardForce;
        return forward + upward;
    }
}
