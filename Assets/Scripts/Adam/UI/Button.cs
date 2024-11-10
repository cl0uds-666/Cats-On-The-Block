using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEngine.Rendering.DebugUI;

public class Button : MonoBehaviour
{
    public GameObject Panel;
    public void Resume()
    {
        Panel.SetActive(false);
        Time.timeScale = 1f;
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("Main_Menu");
    }
}
