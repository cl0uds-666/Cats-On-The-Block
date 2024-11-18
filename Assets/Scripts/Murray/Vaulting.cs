using System.Collections;
using UnityEngine;

public class Vaulting : MonoBehaviour
{
    private int vault_layer;
    public Transform Cam;  
    private float PlayerHeight = 2;
    private float PlayerRadius = 0.5f;

    void Start()
    {
         
        if (Cam == null)
        {
            Cam = transform.Find("Main Camera");  
        }

         
        if (Cam == null)
        {
            Debug.LogError("Camera not found!");
        }

         
        vault_layer = LayerMask.NameToLayer("Vault_Layer");
    }

    void Update()
    {
        OnVault();
    }

    void OnVault()
    {
         
        if (Physics.Raycast(Cam.transform.position, Cam.transform.forward, out var firstHit, 1f, 1 << vault_layer))
        {
            print("Vault possible");

             
            if (Physics.Raycast(firstHit.point + (Cam.transform.forward * PlayerRadius) + (Vector3.up * PlayerHeight * 0.6f), Vector3.down, out var secondHit, PlayerHeight))
            {
                print("Found point to jump to");
                StartCoroutine(LerpVault(secondHit.point, 0.5f));
            }
        }
    }

    
    IEnumerator LerpVault(Vector3 targetPosition, float duration)
    {
        float time = 0;
        Vector3 startPosition = transform.position;

         
        while (time < duration)
        {
            transform.position = Vector3.Lerp(startPosition, targetPosition, time / duration);
            time += Time.deltaTime;
            yield return null;
        }

         
        transform.position = targetPosition;
    }
}
