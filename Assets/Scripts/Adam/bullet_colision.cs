using UnityEngine;

public class bullet_colision : MonoBehaviour
{
    public int Damage;
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
