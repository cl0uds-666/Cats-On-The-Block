using UnityEngine;

public class Purse : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<Missions>().HasPurse = true;
            Destroy(gameObject);
        }
    }
}
