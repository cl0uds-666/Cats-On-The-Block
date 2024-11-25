using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_Stats : MonoBehaviour
{
    public int Health;
    public CinemachineCamera Camera;
    void Start()
    {
        Camera.Prioritize();
    }

    void Update()
    {
        if (Health <= 0)
        {
            SceneManager.LoadScene(" ");
        }
    }
}
