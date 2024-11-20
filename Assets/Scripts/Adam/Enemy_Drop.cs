using UnityEngine;

public class Enemy_Drop : MonoBehaviour
{
    public GameObject ItemDrop;
    void Update()
    {
        if (CompareTag("Enemy"))
        {
            if (GetComponent<EnemyCombat>().Health <= 0)
            {
                Instantiate(ItemDrop, transform.position, Quaternion.identity);
            }
        }

        else
        {
            if (GetComponent<Melee_Enemy>().Health <= 0)
            {
                Instantiate(ItemDrop, transform.position, Quaternion.identity);
            }
        }
    }
}
