using UnityEngine;

public class Open_Pause : MonoBehaviour
{
    public GameObject Panel;
    void OnPause()
    {
        if (Panel.activeSelf)
        {
            Panel.SetActive(false);
            Time.timeScale = 1.0f;
        }

        else
        {
            Panel.SetActive(true);
            Time.timeScale = 0f;
        }
       
    }
}
