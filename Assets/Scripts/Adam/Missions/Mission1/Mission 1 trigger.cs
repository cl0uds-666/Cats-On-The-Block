using Unity.Cinemachine;
using UnityEngine;

public class Mission1trigger : MonoBehaviour
{
    public GameObject Player;
    public CinemachineCamera EnemyCamera;
    public GameObject NPCTextBox, StickPrompts;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && Player.GetComponent<Missions>().Mission == 1)
        {
            StickPrompts.SetActive(false);
            NPCTextBox.SetActive(true);
            EnemyCamera.Prioritize();
            EnemyCamera.GetComponent<CameraSwitch>().SwitchCamera = true;
            Player.GetComponent<Movement>().Speed = 0f;
            Player.GetComponent<Movement>().SprintSpeed = 0f;
            Player.GetComponent<Movement>().CanDash = false;
            Destroy(gameObject);
        }
    }
}
