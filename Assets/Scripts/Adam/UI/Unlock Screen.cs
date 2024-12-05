using TMPro;
using UnityEngine;
using UnityEngine.InputSystem.XInput;
using UnityEngine.UI;

public class UnlockScreen : MonoBehaviour
{
    private GameObject Player;
    public GameObject Pistol, Rifle, Grenade, Bullet, BSkip;
    public Image CurrentWeaponImage, PistolImage, RifleImage, GrenadeImage;
    public TextMeshProUGUI Description;
    private void OnEnable()
    {
        Time.timeScale = 0f;
        BSkip.SetActive(true);
        Player = GameObject.Find("Player");
        
        if (Player.GetComponent<Missions>().Mission == 2)
        {
            CurrentWeaponImage.sprite = PistolImage.sprite;
            Description.text = "Water Pistol: Shoots droplets of water\nDamage: " + Bullet.GetComponent<bullet_colision>().PistolDamage + "\nFire Rate: " + Pistol.GetComponent<PlayerProjectileShooting>().fireRate;
        }

        else if (Player.GetComponent<Missions>().Mission == 3)
        {
            CurrentWeaponImage.sprite = RifleImage.sprite;
            Description.text = "Water Tommy Gun: Shoots droplets of water\nDamage: " + Bullet.GetComponent<bullet_colision>().RifleDamage + "\nFire Rate: " + Rifle.GetComponent<PlayerProjectileShooting>().fireRate;

        }

        else if (Player.GetComponent<Missions>().Mission == 4)
        {
            CurrentWeaponImage.sprite = GrenadeImage.sprite;
            Description.text = "Water Bomb: Explodes Water upon impact and damages all nearby enemies";
        }
    }

    private void Update()
    {
        if (XInputController.current.bButton.isPressed || Input.GetKeyDown(KeyCode.E))
        {
            BSkip.SetActive(false);
            gameObject.SetActive(false);
            Time.timeScale = 1.0f;
        }
    }
}
