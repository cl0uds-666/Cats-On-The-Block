using UnityEngine;

public class Enemy_Bullet : MonoBehaviour
{
    public float Speed;
    public GameObject Player;
    public bool Move;
    public float DeathTimer;
    public int Damage;

    void Update()
    {
        if (Move)
        {
            transform.position = Vector3.MoveTowards(transform.position, Player.transform.position, Speed * Time.deltaTime);
        }

        if (DeathTimer <= 0)
        {
            Destroy(gameObject);
        }

        else if (DeathTimer <= 5f)
        {
            DeathTimer -= Time.deltaTime;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.gameObject.CompareTag("Enemy") && !collision.gameObject.CompareTag("Bullet"))
        {
            Destroy(gameObject);
        }

        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Player_Stats>().Health -= Damage;
        }
    }
}
