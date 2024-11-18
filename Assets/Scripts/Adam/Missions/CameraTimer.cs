using Unity.Cinemachine;
using UnityEngine;

public class CameraTimer : MonoBehaviour
{
    public bool StartTimer = false;
    public float MaxCameraTimer;
    private float CurrentCameraTimer;
    public CinemachineCamera PlayerCamera;
    public GameObject Enemy;

    private void Start()
    {
        Enemy.GetComponent<EnemyMovement>().enabled = false;
        Enemy.GetComponent<Melee_Enemy>().enabled = false;
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

            if (CurrentCameraTimer <= MaxCameraTimer - 1f)
            {
                Enemy.GetComponent<EnemyMovement>().enabled = true;
            }
        }
    }
}
