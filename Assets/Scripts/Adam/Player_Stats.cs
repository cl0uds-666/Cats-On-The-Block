using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_Stats : MonoBehaviour
{
    public int Health;
    public int MaxHealth;
    public CinemachineCamera Camera;

    private int Deathcount = 0;
    private int MaxDeath = 0;

    void Start()
    {
        Camera.Prioritize();
        Health = MaxHealth;
    }

    void Update()
    {
        if (Health <= 0)
        {
            Death();
        }

    }

    public void ResetHealth()
    {
        Health = MaxHealth;
    }

    private void Death()
    {
        Deathcount++;

        if (Deathcount >= MaxDeath)
        {
            SceneManager.LoadScene("GameoverScreen");
            print("Reapwnn");
        }
        else
        {
            var missions = FindAnyObjectByType<Missions>();
            if (missions != null)
            {
                
                missions.Respawn();
            }
            else
            {
                SceneManager.LoadScene("GameoverScreen");// back up so it doesn't scrash if script doesn't work

            }
        }

    }
}
