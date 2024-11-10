using UnityEngine;

public class bullet_colision : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<EnemyCombat>().Health -= GetComponent<Bullet>().damage;
        }

        if (collision.gameObject.CompareTag("Melee Enemy"))
        {
            collision.gameObject.GetComponent<Melee_Enemy>().Health -= GetComponent<Bullet>().damage;
        }
    }
}
