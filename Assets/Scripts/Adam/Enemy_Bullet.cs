using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

public class Enemy_Bullet : MonoBehaviour
{
    public float Speed;
    public GameObject Player;
    private Rigidbody rb;
    public bool Move;
    public float DeathTimer;
    public int Damage;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        if (Move)
        {
            rb.AddForce(transform.forward * Speed);
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
