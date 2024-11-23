using UnityEngine;

public class Enemy_Drop : MonoBehaviour
{
    public GameObject ItemDrop;
    private GameObject Player;

    private void Start()
    {
        Player = GameObject.Find("Player");
    }

    void Update()
    {
        if (CompareTag("Enemy"))
        {
            if (GetComponent<EnemyCombat>().Health <= 0 && !Player.GetComponent<Missions>().Mission3ParkEnemies.Contains(gameObject))
            {
                Instantiate(ItemDrop, transform.position, Quaternion.identity);
            }

            else if (GetComponent<EnemyCombat>().Health <= 0 && Player.GetComponent<Missions>().Mission3ParkEnemies.Contains(gameObject) && Player.GetComponent<Missions>().Mission3ParkEnemies.Count == 3)
            {
                print("Spawn");
                Instantiate(ItemDrop, transform.position, Quaternion.identity);
            }
        }

        else
        {
            if (GetComponent<Melee_Enemy>().Health <= 0 && !Player.GetComponent<Missions>().Mission3ParkEnemies.Contains(gameObject))
            {
                Instantiate(ItemDrop, transform.position, Quaternion.identity);
            }

            else if (GetComponent<Melee_Enemy>().Health <= 0 && Player.GetComponent<Missions>().Mission3ParkEnemies.Contains(gameObject) && Player.GetComponent<Missions>().Mission3ParkEnemies.Count == 3)
            {
                print("Spawn");
                Instantiate(ItemDrop, transform.position, Quaternion.identity);
            }
        }
    }
}
