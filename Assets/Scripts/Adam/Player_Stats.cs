using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_Stats : MonoBehaviour
{
    public int Health;
    public int MaxHealth;
    public CinemachineCamera Camera;
    void Start()
    {
        Camera.Prioritize();
        Health = MaxHealth;
    }

    void Update()
    {
        if (Health <= 0)
        {
            SceneManager.LoadScene("GameoverScreen");
        }

    }

    public void ResetHealth()
    {
        Health = MaxHealth;
    }
}
