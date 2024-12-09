using UnityEngine;
using UnityEngine.InputSystem;

public class Open_Pause : MonoBehaviour
{
    public GameObject Panel, UnlockScreen, MiniMap;
    void OnPause(InputValue value)
    {
        print("Pause");

        if (!UnlockScreen.activeSelf)
        {
            if (Panel.activeSelf)
            {
                GetComponent<PlayerInput>().SwitchCurrentActionMap("Player");
                Panel.SetActive(false);
                MiniMap.SetActive(true);
                Time.timeScale = 1.0f;
            }

            else
            {
                GetComponent<PlayerInput>().SwitchCurrentActionMap("UI");
                Panel.SetActive(true);
                MiniMap.SetActive(false);
                Time.timeScale = 0f;
            }
        }
    }
}
