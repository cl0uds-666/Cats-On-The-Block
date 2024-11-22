using UnityEngine;

public class GunPIckUp : MonoBehaviour
{
    private GameObject Player;

    private void Start()
    {
        Player = GameObject.Find("Player");
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (Player.GetComponent<Missions>().Mission == 2 && other.CompareTag("Player"))
        {
            print("gun");
            Player.GetComponent<WeaponSwitching>().weapons.Add(gameObject);
        }
    }
}
