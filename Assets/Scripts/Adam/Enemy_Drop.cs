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
            if (GetComponent<EnemyCombat>().Health <= 0 && !Player.GetComponent<Missions>().Mission3ParkEnemies.Contains(gameObject) && !Player.GetComponent<Missions>().Mission4ConstructionEnemies.Contains(gameObject))
            {
                Instantiate(ItemDrop, transform.position, Quaternion.identity);
                print("Skibidi");
                Destroy(gameObject);
            }

            else if (GetComponent<EnemyCombat>().Health <= 0)
            {
                if (Player.GetComponent<Missions>().Mission3ParkEnemies.Contains(gameObject))
                {
                    if (Player.GetComponent<Missions>().Mission3ParkEnemies.Count == 1)
                    {
                        Instantiate(ItemDrop, transform.position, Quaternion.identity);
                    }
                    Player.GetComponent<Missions>().Mission3ParkEnemies.Remove(gameObject);
                }

                else if (Player.GetComponent<Missions>().Mission4ConstructionEnemies.Contains(gameObject))
                {
                    if (Player.GetComponent<Missions>().Mission4ConstructionEnemies.Count == 1)
                    {
                        Instantiate(ItemDrop, transform.position, Quaternion.identity);
                    }
                    Player.GetComponent<Missions>().Mission4ConstructionEnemies.Remove(gameObject);
                }

                Destroy(gameObject);
            }
        }

        else
        {
            if (GetComponent<Melee_Enemy>().Health <= 0 && !Player.GetComponent<Missions>().Mission3ParkEnemies.Contains(gameObject) && !Player.GetComponent<Missions>().Mission4ConstructionEnemies.Contains(gameObject))
            {
                Instantiate(ItemDrop, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }

            else if (GetComponent<Melee_Enemy>().Health <= 0)
            {
                if (Player.GetComponent<Missions>().Mission3ParkEnemies.Contains(gameObject))
                {
                    if (Player.GetComponent<Missions>().Mission3ParkEnemies.Count == 1)
                    {
                        Instantiate(ItemDrop, transform.position, Quaternion.identity);
                    }
                    Player.GetComponent<Missions>().Mission3ParkEnemies.Remove(gameObject);
                }

                else if (Player.GetComponent<Missions>().Mission4ConstructionEnemies.Contains(gameObject))
                {
                    if (Player.GetComponent<Missions>().Mission4ConstructionEnemies.Count == 1)
                    {
                        Instantiate(ItemDrop, transform.position, Quaternion.identity);
                    }
                    Player.GetComponent<Missions>().Mission4ConstructionEnemies.Remove(gameObject);
                }

                Destroy(gameObject);
            }
        }
    }
}
