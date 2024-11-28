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
                GameObject Item = Instantiate(ItemDrop, transform.position, Quaternion.identity);

                if (Item.gameObject.name == "Pistol_(Clone)")
                {
                    Player.GetComponent<Missions>().Pistol = Item;
                }

                Destroy(gameObject);
            }

            else if (GetComponent<EnemyCombat>().Health <= 0)
            {
                if (Player.GetComponent<Missions>().Mission3ParkEnemies.Contains(gameObject))
                {
                    if (Player.GetComponent<Missions>().Mission3ParkEnemies.Count == 1)
                    {
                        GameObject Item = Instantiate(ItemDrop, transform.position, Quaternion.identity);

                        if (Item.gameObject.name == "Tommy_Gun_(Clone)")
                        {
                            Player.GetComponent<Missions>().Rifle = Item;
                        }
                    }
                    Player.GetComponent<Missions>().Mission3ParkEnemies.Remove(gameObject);
                }

                else if (Player.GetComponent<Missions>().Mission4ConstructionEnemies.Contains(gameObject))
                {
                    if (Player.GetComponent<Missions>().Mission4ConstructionEnemies.Count == 1)
                    {
                        GameObject Item = Instantiate(ItemDrop, transform.position, Quaternion.identity);

                        if (Item.gameObject.name == "Grenade_(Clone)")
                        {
                            Player.GetComponent<Missions>().Grenade = Item;
                        }
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
                GameObject Item = Instantiate(ItemDrop, transform.position, Quaternion.identity);

                if (Item.gameObject.name == "Purse(Clone)")
                {
                    Player.GetComponent<Missions>().PurseObject = Item;
                }

                Destroy(gameObject);
            }

            else if (GetComponent<Melee_Enemy>().Health <= 0)
            {
                if (Player.GetComponent<Missions>().Mission3ParkEnemies.Contains(gameObject))
                {
                    if (Player.GetComponent<Missions>().Mission3ParkEnemies.Count == 1)
                    {
                        GameObject Item = Instantiate(ItemDrop, transform.position, Quaternion.identity);

                        if (Item.gameObject.name == "Tommy_Gun_(Clone)")
                        {
                            Player.GetComponent<Missions>().Rifle = Item;
                        }
                    }
                    Player.GetComponent<Missions>().Mission3ParkEnemies.Remove(gameObject);
                }

                else if (Player.GetComponent<Missions>().Mission4ConstructionEnemies.Contains(gameObject))
                {
                    if (Player.GetComponent<Missions>().Mission4ConstructionEnemies.Count == 1)
                    {
                        GameObject Item = Instantiate(ItemDrop, transform.position, Quaternion.identity);

                        if (Item.gameObject.name == "Grenade_(Clone)")
                        {
                            Player.GetComponent<Missions>().Grenade = Item;
                        }
                    }
                    Player.GetComponent<Missions>().Mission4ConstructionEnemies.Remove(gameObject);
                }

                Destroy(gameObject);
            }
        }
    }
}
