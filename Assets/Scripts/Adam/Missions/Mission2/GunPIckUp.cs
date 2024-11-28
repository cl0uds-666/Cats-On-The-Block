using UnityEngine;
using UnityEngine.UI;

public class GunPIckUp : MonoBehaviour
{
    private GameObject Player;
    private GameObject GunPosition;
    public GameObject Wheel;
    public Sprite PistolSprite;

    private void Start()
    {
        Player = GameObject.Find("Player");
        GunPosition = GameObject.Find("GunPosition");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (CompareTag("Pistol") && Player.GetComponent<Missions>().Mission == 2 || CompareTag("Rifle") && Player.GetComponent<Missions>().Mission == 3 || CompareTag("Grenade") && Player.GetComponent<Missions>().Mission == 4)
            {
                Player.GetComponent<WeaponSwitching>().weapons.Add(gameObject);
                transform.parent = Player.transform;
                transform.position = GunPosition.transform.position;
                transform.localRotation = Quaternion.Euler(transform.localPosition.x, 90, transform.localPosition.z);
                Player.GetComponent<Missions>().SelectMission();
                Wheel.GetComponent<Image>().sprite = PistolSprite;
            }
        }
    }
}
