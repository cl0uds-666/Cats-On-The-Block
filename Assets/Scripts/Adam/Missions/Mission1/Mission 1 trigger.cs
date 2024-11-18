using Unity.Cinemachine;
using UnityEngine;

public class Mission1trigger : MonoBehaviour
{
    public GameObject Player;
    public CinemachineCamera EnemyCamera;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && Player.GetComponent<Missions>().Mission == 1)
        {
            EnemyCamera.Prioritize();
            EnemyCamera.GetComponent<CameraTimer>().StartTimer = true;
            Destroy(gameObject);
        }
    }
}
