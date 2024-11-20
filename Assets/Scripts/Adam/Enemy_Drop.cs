using UnityEngine;

public class Enemy_Drop : MonoBehaviour
{
    public GameObject ItemDrop;
    void Update()
    {
        if (CompareTag("Enemy") || CompareTag("Melee Enemy"))
        {
            Instantiate(ItemDrop, transform.position, Quaternion.identity);
        }
    }
}
