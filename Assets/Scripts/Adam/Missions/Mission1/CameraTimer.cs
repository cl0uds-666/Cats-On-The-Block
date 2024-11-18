using Unity.Cinemachine;
using UnityEngine;

public class CameraTimer : MonoBehaviour
{
    public bool StartTimer = false;
    public float MaxCameraTimer;
    private float CurrentCameraTimer;
    public CinemachineCamera PlayerCamera;
    public GameObject Enemy;
    public GameObject AttackBox;
    private void Start()
    {
        Enemy.GetComponent<EnemyMovement>().enabled = false;
        Enemy.GetComponent<Melee_Enemy>().enabled = false;
        AttackBox.SetActive(false);
        CurrentCameraTimer = MaxCameraTimer;
    }

    void Update()
    {
        if (StartTimer)
        {
            if (CurrentCameraTimer > 0f)
            {
                CurrentCameraTimer -= Time.deltaTime;
            }

            else
            {
                PlayerCamera.Prioritize();
            }

            if (CurrentCameraTimer <= MaxCameraTimer - 1f && CurrentCameraTimer > 0f)
            {
                Enemy.GetComponent<EnemyMovement>().enabled = true;
            }
        }
    }
}
