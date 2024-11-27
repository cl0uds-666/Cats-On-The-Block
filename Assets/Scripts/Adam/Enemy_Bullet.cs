using UnityEngine;

public class Enemy_Bullet : MonoBehaviour
{
    public float Speed;
    private GameObject Player;
    public bool Move;
    public float DeathTimer;
    public int Damage;

    private void Start()
    {
        Player = GameObject.Find("Player");
    }

    void Update()
    {
        if (Move)
        {
            transform.position = Vector3.MoveTowards(transform.position, Player.transform.GetComponent<Renderer>().bounds.center, Speed * Time.deltaTime);
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
