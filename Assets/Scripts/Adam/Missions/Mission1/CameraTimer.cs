using Unity.Cinemachine;
using UnityEngine;

public class CameraTimer : MonoBehaviour
{
    public bool StartTimer = false;
    public float MaxCameraTimer;
    public float CurrentCameraTimer;
    public CinemachineCamera PlayerCamera;
    public GameObject Enemy;
    public GameObject AttackBox;
    public GameObject Player;
    private float NormalSpeed;
    private float NormalSprintSpeed;
    public GameObject NPCTextBox;
    public GameObject NPC;
    private void Start()
    {
        Enemy.GetComponent<EnemyMovement>().enabled = false;
        Enemy.GetComponent<Melee_Enemy>().enabled = false;
        AttackBox.SetActive(false);
        CurrentCameraTimer = MaxCameraTimer;
        NormalSpeed = Player.GetComponent<Movement>().Speed;
        NormalSprintSpeed = Player.GetComponent<Movement>().SprintSpeed;
    }

    void Update()
    {
        if (StartTimer)
        {
            if (CurrentCameraTimer > 0f)
            {
                CurrentCameraTimer -= Time.deltaTime;
                NPC.transform.LookAt(new Vector3(Player.transform.position.x, NPC.transform.position.y, Player.transform.position.z));
            }

            else
            {
                StartTimer = false;
                PlayerCamera.Prioritize();
                NPCTextBox.SetActive(false);
                Player.GetComponent<Movement>().Speed = NormalSpeed;
                Player.GetComponent<Movement>().SprintSpeed = NormalSprintSpeed;
            }

            if (CurrentCameraTimer <= MaxCameraTimer - 1f && CurrentCameraTimer > 0f)
            {
                Enemy.GetComponent<EnemyMovement>().enabled = true;
            }
        }
    }
}
