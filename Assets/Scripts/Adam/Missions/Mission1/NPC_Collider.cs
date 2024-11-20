using UnityEngine;

public class NPC_Collider : MonoBehaviour
{
    public bool Mission1Complete;
    private GameObject Player;

    private void Start()
    {
        Player = GameObject.Find("Player");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && Player.GetComponent<Missions>().HasPurse)
        {
            Mission1Complete = true;
        }
    }
}
