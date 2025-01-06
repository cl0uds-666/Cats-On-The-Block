using UnityEngine;

public class bullet_colision : MonoBehaviour
{
    private int Damage;
    public int PistolDamage, RifleDamage;
    private GameObject Player;

    private void Start()
    {
        Player = GameObject.Find("Player");
        Player.GetComponent<BulletVibration>().CanVibrate = true;

        if (Player.GetComponent<WeaponSwitching>().currentWeaponIndex == 1)
        {
            Damage = PistolDamage;
        }

        else
        {
            Damage = RifleDamage;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<EnemyCombat>().Health -= Damage;
            Destroy(gameObject);
        }

        if (collision.gameObject.CompareTag("Melee Enemy"))
        {
            collision.gameObject.GetComponent<Melee_Enemy>().Health -= Damage;
            Destroy(gameObject);
        }
    }
}
