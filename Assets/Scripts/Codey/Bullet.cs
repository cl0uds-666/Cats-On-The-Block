using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damage = 10;

    private void OnCollisionEnter(Collision collision)
    {
        // Apply damage if the object has a health component
        Player_Stats target = collision.collider.GetComponent<Player_Stats>();
        if (target != null)
        {
            target.Health -= damage;
        }

        // Destroy the bullet on impact
        Destroy(gameObject);
    }
}
