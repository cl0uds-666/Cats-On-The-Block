using UnityEngine;

public class MinMAp : MonoBehaviour
{
    public GameObject Player;
    void Update()
    {
        transform.position = new Vector3(Player.transform.position.x, transform.position.y, Player.transform.position.z);
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, Player.transform.eulerAngles.y, transform.eulerAngles.z);
    }
}
