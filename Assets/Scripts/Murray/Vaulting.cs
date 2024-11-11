using System.Collections;
using UnityEngine;

public class Vaulting : MonoBehaviour
{
    private int vault_layer;
    public Transform Cam; // Camera Transform to be assigned
    private float PlayerHeight = 2;
    private float PlayerRadius = 0.5f;

    void Start()
    {
        // Automatically find the camera as a child of the player
        if (Cam == null)
        {
            Cam = transform.Find("CameraName");  // Replace "CameraName" with the actual name of your camera GameObject
        }

        // Check if Cam is still null and handle the error if camera is not found
        if (Cam == null)
        {
            Debug.LogError("Camera not found! Make sure the Camera GameObject is a child of the player or assigned properly.");
        }

        // Directly get the vault layer without inverting it
        vault_layer = LayerMask.NameToLayer("Vault_Layer");
    }

    void Update()
    {
        OnVault();
    }

    void OnVault()
    {
        // Raycast to detect a vaultable object
        if (Physics.Raycast(Cam.transform.position, Cam.transform.forward, out var firstHit, 1f, 1 << vault_layer))
        {
            print("Vault possible");

            // Check if there's a solid surface to jump to (above the detected object)
            if (Physics.Raycast(firstHit.point + (Cam.transform.forward * PlayerRadius) + (Vector3.up * PlayerHeight * 0.6f), Vector3.down, out var secondHit, PlayerHeight))
            {
                print("Found point to jump to");
                StartCoroutine(LerpVault(secondHit.point, 0.5f));
            }
        }
    }

    // Smooth vault transition with Lerp
    IEnumerator LerpVault(Vector3 targetPosition, float duration)
    {
        float time = 0;
        Vector3 startPosition = transform.position;

        // Lerp the player position smoothly to the target position
        while (time < duration)
        {
            transform.position = Vector3.Lerp(startPosition, targetPosition, time / duration);
            time += Time.deltaTime;
            yield return null;
        }

        // Final position set to target position
        transform.position = targetPosition;
    }
}
