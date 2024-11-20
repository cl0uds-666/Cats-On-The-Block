using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_Stats : MonoBehaviour
{
    public int Health;
    
    void Start()
    {
        
    }

    void Update()
    {
        if (Health <= 0)
        {
            SceneManager.LoadScene("Main Menu");
        }
    }
}
