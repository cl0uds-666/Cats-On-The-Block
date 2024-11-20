using Unity.Cinemachine;
using UnityEditor.ShaderGraph;
using UnityEngine;

public class Mission1trigger : MonoBehaviour
{
    public GameObject Player;
    public CinemachineCamera EnemyCamera;
    public GameObject NPCTextBox;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && Player.GetComponent<Missions>().Mission == 1)
        {
            EnemyCamera.Prioritize();
            EnemyCamera.GetComponent<CameraTimer>().StartTimer = true;
            NPCTextBox.SetActive(true);
            Player.GetComponent<Movement>().Speed = 0f;
            Player.GetComponent<Movement>().SprintSpeed = 0f;
            Destroy(gameObject);
        }
    }
}
