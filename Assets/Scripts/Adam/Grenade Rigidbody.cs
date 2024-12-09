using UnityEngine;

public class GrenadeRigidbody : MonoBehaviour
{
    private GameObject Player;
    void Start()
    {
        Player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (Player.GetComponent<WeaponSwitching>().weapons.Contains(gameObject))
        {
            GetComponent<Rigidbody>().isKinematic = true;
        }
    }
}
