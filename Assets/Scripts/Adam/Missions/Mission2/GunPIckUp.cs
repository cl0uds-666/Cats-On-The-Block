using UnityEngine;

public class GunPIckUp : MonoBehaviour
{
    private GameObject Player;
    private GameObject GunPosition;

    private void Start()
    {
        Player = GameObject.Find("Player");
        GunPosition = GameObject.Find("GunPosition");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (Player.GetComponent<Missions>().Mission == 2 && other.CompareTag("Player"))
        {
            Player.GetComponent<WeaponSwitching>().weapons.Add(gameObject);
            transform.parent = Player.transform;
            transform.position = GunPosition.transform.position;
            transform.localRotation = Quaternion.Euler(transform.localPosition.x, 90, transform.localPosition.z);
            Player.GetComponent<Missions>().SelectMission();
        }
    }
}
